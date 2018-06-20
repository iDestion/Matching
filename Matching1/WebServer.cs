using System;
using System.Net;
using System.Text;
using System.Threading;

namespace Matching1
{
    public class WebServer
    {
        private readonly HttpListener listener = new HttpListener();
        private readonly Func<HttpListenerRequest, string> responderMethod;
 
        public WebServer(string[] prefixes, Func<HttpListenerRequest, string> method)
        {
            if (!HttpListener.IsSupported)
                throw new NotSupportedException(
                    "Needs Windows XP SP2, Server 2003 or later.");
 
            // URI prefixes are required, for example 
            // "http://localhost:8080/index/".
            if (prefixes == null || prefixes.Length == 0)
                throw new ArgumentException("prefixes");
 
            // A responder method is required
            if (method == null)
                throw new ArgumentException("method");
 
            foreach (string s in prefixes)
                listener.Prefixes.Add(s);
 
            responderMethod = method;
            listener.Start();
        }
 
        public WebServer(Func<HttpListenerRequest, string> method, params string[] prefixes)
            : this(prefixes, method) { }

        public void Run()
        {
            ThreadPool.QueueUserWorkItem((o) =>
            {
                Console.WriteLine("Webserver running...");
                try
                {
                    while (listener.IsListening)
                    {
                        ThreadPool.QueueUserWorkItem((c) =>
                        {
                            var ctx = c as HttpListenerContext;
                            try
                            {
                                string rstr = responderMethod(ctx.Request);
                                byte[] buf = Encoding.UTF8.GetBytes(rstr);
                                ctx.Response.ContentLength64 = buf.Length;
                                ctx.Response.OutputStream.Write(buf, 0, buf.Length);
                            }
                            catch
                            {
                                // ignored
                            } // suppress any exceptions
                            finally
                            {
                                // always close the stream
                                ctx.Response.OutputStream.Close();
                            }
                        }, listener.GetContext());
                    }
                }
                catch
                {
                    // ignored
                } // suppress any exceptions
            });
        }
 
        public void Stop()
        {
            listener.Stop();
            listener.Close();
        }
    }
}