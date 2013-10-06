using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatanaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string uri = "http://localhost:8080/";
 
            using (WebApp.Start<Startup>(uri))
            {
                Console.WriteLine("Started");
                Console.ReadKey();
                Console.WriteLine("Stopping");
            }                 
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // from Owin.Diagnostics
            // app.UseWelcomePage();

            // low level app.Run
            app.Run(ctx =>
            {
                foreach (var kvp in ctx.Environment)
                {
                    Console.WriteLine("{0}:{1}", kvp.Key, kvp.Value);
                }
                return ctx.Response.WriteAsync("Hello!");
            });


            // Synch Handler
            // app.UseHandler((request, response) => 
            //    {                    
            //       response.Write("Hello!"); 
            //    });

            // Asynch handler
            //app.UseHandlerAsync((request, response) =>
            //{
            //    response.ContentType = "text/plain";
            //    return response.WriteAsync("Hello!");
            //});
        }
    }
}
