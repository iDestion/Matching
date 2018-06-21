using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Matching1
{
    public static class DBUtils
    {

        public static List<Team> GenerateTeamList()
        {



            return null;
        }

        public static Project
        {
            
            return null;
        }

        public static void StoreMatch(Match match, MySqlConnection conn)
        {
            String query = "INSERT INTO match (p_id, t1_id, t2_id) VALUES " + match.GetProject().getId() +
                           ", " + match.GetEuTeam().getId() + ", " + match.GetAfTeam().getId();
            
            MySqlCommand cmd = new MySqlCommand(query, conn);
            
        }
        
    }
}