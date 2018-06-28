using System;
using System.IO;
using System.Net;
using System.Text;
using MySql.Data.MySqlClient;

namespace Matching1
{
    class HTTPServer
    {
        private HttpListener listener;
        private MySqlConnection conn;
        public HTTPServer() { }
        public bool Start()
        {
            listener = new HttpListener();
            listener.Prefixes.Add("http://+:80/");
            listener.Start();
            listener.BeginGetContext(new AsyncCallback(ListenerCallback), listener);
            
            //Database
            this.conn = new MySqlConnection();
           
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
            
            //Setup DbUtils init
            DbUtils.SetConn(conn);
            DbUtils.DoFetch();
            
            return true;
        }
        private static void ListenerCallback(IAsyncResult result)
        {
            HttpListener listener = (HttpListener)result.AsyncState;
            listener.BeginGetContext(new AsyncCallback(ListenerCallback), listener);
            Console.WriteLine("New request.");

            HttpListenerContext context = listener.EndGetContext(result);
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;
            
            DbUtils.DoFetch();

            //Try to handle the request with the corresponding id from database
            try
            {
                string id = context.Request.Url.Segments[1].Replace("/", "");
                
                TwoFactorMatcher matcher = new TwoFactorMatcher(Data.GetTeams(), Data.getProjectById(Int32.Parse(id)));
                Match match = matcher.DoMatching();
                
                DbUtils.StoreMatch(match);
                
                byte[] page = Encoding.UTF8.GetBytes(match.ToString());
                response.ContentLength64 = page.Length;
                Stream output = response.OutputStream;
                output.Write(page, 0, page.Length);
                output.Close();
            }
            //If no valid id is provided, return a warning
            catch (Exception e)
            {
                byte[] page = Encoding.UTF8.GetBytes("No valid id provided");
                response.ContentLength64 = page.Length;
                Stream output = response.OutputStream;
                output.Write(page, 0, page.Length);
                output.Close();
            }

        }
    }
}