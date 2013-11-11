using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatanaAppFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            string uri = "http://localhost:8080";

            using (WebApp.Start<Startup>(uri))
            {
                Console.WriteLine("Start");
                Console.ReadLine();
                Console.WriteLine("End");
            }
        }
    }
}
