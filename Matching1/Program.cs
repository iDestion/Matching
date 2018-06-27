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
//            String query = "SELECT * FROM project";
//            MySqlCommand command = new MySqlCommand(query, conn);
//            MySqlDataReader reader = command.ExecuteReader();
//            while (reader.Read())
//            {
//                Console.WriteLine(reader.GetString("id"));
//                Console.WriteLine(reader.GetString("name"));
//                Console.WriteLine(reader.GetString("description"));
//                Console.WriteLine(reader.GetString("language"));
//                
//            }
//            reader.close();
            
//            DbUtils.StoreMatch(match);
            
            //currently take random proj from list, testing purposes
            
            HTTPServer server = new HTTPServer();
            server.Start();
            Console.WriteLine("Attempt number 2. Press a key to quit.");
            Console.ReadKey();
        }
    }
}