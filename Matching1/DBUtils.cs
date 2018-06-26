using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using MySql.Data.MySqlClient;

namespace Matching1
{
    public static class DbUtils
    {
        private static MySqlConnection conn;

        public static void SetConn(MySqlConnection connect)
        {
            conn = connect;
        }
        
        public static void DoFetch()
        {
            //Setup for queries
            String projquery = "SELECT * FROM project";
            String teamquery = "SElECT * FROM team";
            String criterionquery = "SELECT * FROM criteria";
            String skillquery = "SELECT * FROM skill";
            
            MySqlCommand projcommand = new MySqlCommand(projquery, conn);
            MySqlCommand teamcommand = new MySqlCommand(teamquery, conn);
            MySqlCommand criterioncommand = new MySqlCommand(criterionquery, conn);
            MySqlCommand skillcommand = new MySqlCommand(skillquery, conn);

            List<Project> projects = new List<Project>();
            List<Team> teams = new List<Team>();
            Dictionary<int, Tuple<string, int>> critdict = new Dictionary<int, Tuple<string, int>>();
            Dictionary<int, string> skilldict = new Dictionary<int, string>();

            MySqlDataReader critreader = criterioncommand.ExecuteReader();

            while (critreader.Read())
            {
                Tuple<string, int> tempTuple = new Tuple<string, int>(critreader.GetString("criterion"), 
                    critreader.GetInt32("weight"));
                critdict.Add(critreader.GetInt32("p_id"), tempTuple);
            }
            
            critreader.Close();

            MySqlDataReader skillreader = skillcommand.ExecuteReader();

            while (skillreader.Read())
            {
                skilldict.Add(skillreader.GetInt32("t_id"), skillreader.GetString("skill"));
            }
            
            skillreader.Close();
            
            MySqlDataReader projreader = projcommand.ExecuteReader();
            //Read trough the project table
            while (projreader.Read())
            {
                int id = projreader.GetInt32("id");
                String name = projreader.GetString("name");
                String language = projreader.GetString("language");
                
                //match criteria from critdict
                List<Criterion> criteria = new List<Criterion>();

                foreach (KeyValuePair<int, Tuple<string, int>> entry in critdict)
                {
                    if (entry.Key == id)
                    {
                        criteria.Add(new Criterion(entry.Value.Item1, entry.Value.Item2));
                    }
                }
                
                Project tempproj = new Project(criteria, language, name, id);
                projects.Add(tempproj);
            }
            projreader.Close();
            
            MySqlDataReader teamreader = teamcommand.ExecuteReader();
            //Read trough the team table
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
                
                //match skills from the skilldict
                List<Skill> skills = new List<Skill>();

                foreach (KeyValuePair<int, string> entry in skilldict)
                {
                    if (entry.Key == id)
                    {
                        skills.Add(new Skill(entry.Value));
                    }
                }
                
                Team tempteam = new Team(skills, languages, isAfrican, name, id, isAvailable);
                teams.Add(tempteam);
            }
            teamreader.Close();
            
            Data.SetProjects(projects);
            Data.SetTeams(teams);
            
        }

        public static void StoreMatch(Match match)
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