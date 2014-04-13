using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatanaMiddleware
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
            app.Use(async (ctx, next) =>
            {
                // pre handler
                Console.WriteLine("Getting request " + ctx.Request.Path);

                await next();

                // post handler

                Console.WriteLine("\tSending response: " + ctx.Response.StatusCode);

            });
            
            app.Run(ctx =>
            {
                return ctx.Response.WriteAsync("Hello!");
            });  

           

                
        }
    }
}
