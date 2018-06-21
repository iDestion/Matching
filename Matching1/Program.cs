using System;
using System.Collections.Generic;
using System.Net;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Matching1
{
    class Program
    {
        static void Main(string[] args)
        {
            Skill skill01 = new Skill("Test01");
            Skill skill02 = new Skill("Test02");
            Skill skill03 = new Skill("Test03");
            Skill skill04 = new Skill("Test04");
            
            Criterion crit01 = new Criterion("Test01", 10);
            Criterion crit02 = new Criterion("Test02", 10);
            Criterion crit03 = new Criterion("Test03", 10);
            Criterion crit04 = new Criterion("Test04", 25);
            
            List<Criterion> critlist = new List<Criterion>();
            List<Skill> skilllist = new List<Skill>();
            
            critlist.Add(crit01);
            critlist.Add(crit02);
            critlist.Add(crit03);
            critlist.Add(crit04);
            
            skilllist.Add(skill01);
            skilllist.Add(skill02);
            skilllist.Add(skill03);
            skilllist.Add(skill04);
            
            
            Project project = new Project(critlist, "German", "Ziekenhuis Project");
            List<String> langlist = new List<string>();
            langlist.Add("Dutch");
            langlist.Add("German");
            Team euteam = new Team(skilllist, langlist, false, "van den Berg ICT");
            Team afteam = new Team(skilllist, langlist, true, "Okafor Solutions");
            
            List<Team> teams = new List<Team>();
            teams.Add(euteam);
            teams.Add(afteam);
            
            TwoFactorMatcher matcher = new TwoFactorMatcher(teams, project);
            Match match = matcher.DoMatching();
            match.ToString();
            
            
            //Database testing
            MySqlConnection conn = new MySqlConnection();
           
            conn.ConnectionString =
                "Data Source=micksneekes.nl;" +
                "Initial Catalog=ftfs;" +
                "User id=root;" +
                "Password=Qwerty@123;" +
                "SslMode=none";
            try
            {
                conn.Open();
                Console.WriteLine("Connection established to database.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            String query = "SELECT * FROM project";
            MySqlCommand command = new MySqlCommand(query, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                
            }
            reader.Close();
            
            
            
            
            
            
            
            //Websockets
            WebServer ws = new WebServer(SendResponse, "http://localhost:8080/test/");
            ws.Run();
            Console.WriteLine("A simple webserver. Press a key to quit.");
            Console.ReadKey();
            ws.Stop();
            conn.Close();
        }

        public static string SendResponse(HttpListenerRequest request)
        {
            return string.Format("<HTML><BODY>My web page.<br>{0}</BODY></HTML>", DateTime.Now);    
        }
        
    }
}