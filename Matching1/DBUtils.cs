using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Matching1
{
    public static class DbUtils
    {
        public static void DoFetch(MySqlConnection conn)
        {
            String projquery = "SELECT * FROM project";
            String teamquery = "SElECT * FROM team";
            
            MySqlCommand projcommand = new MySqlCommand(projquery, conn);
            MySqlCommand teamcommand = new MySqlCommand(teamquery, conn);
            MySqlDataReader projreader = projcommand.ExecuteReader();

            List<Project> projects = new List<Project>();
            List<Team> teams = new List<Team>();
            
            while (projreader.Read())
            {
                int id = projreader.GetInt32("id");
                String name = projreader.GetString("name");
                String language = projreader.GetString("language");
                
                Project tempproj = new Project(null, language, name, id);
                projects.Add(tempproj);
            }
            projreader.Close();
            
            MySqlDataReader teamreader = teamcommand.ExecuteReader();

            while (teamreader.Read())
            {
                int id = teamreader.GetInt32("id");
                String name = teamreader.GetString("name");
                String language = teamreader.GetString("language");
                bool isAfrican = teamreader.GetBoolean("is_african");
                bool isAvailable = teamreader.GetBoolean("is_available");

                //Language is now single instance, make multiple available with additional table
                List<String> languages = new List<String>();
                languages.Add(language);
                
                Team tempteam = new Team(null, languages, isAfrican, name, id, isAvailable);
                teams.Add(tempteam);
            }
            teamreader.Close();
            
            Data.SetProjects(projects);
            Data.SetTeams(teams);
            
        }

        public static void StoreMatch(Match match, MySqlConnection conn)
        {
            
            //Handle simple match storing
            MySqlCommand cmd = new MySqlCommand("", conn);
            cmd.CommandText = "INSERT INTO `match` (`p_id`, `t1_id`, `t2_id`) VALUES (?p_id,?t1_id,?t2_id)";
            cmd.Parameters.Add("?p_id", MySqlDbType.Int32).Value = match.GetProject().getId();
            cmd.Parameters.Add("?t1_id", MySqlDbType.Int32).Value = match.GetAfTeam().getId();
            cmd.Parameters.Add("?t2_id", MySqlDbType.Int32).Value = match.GetEuTeam().getId();

            cmd.ExecuteNonQuery();
        }
        
    }
}