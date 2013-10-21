using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using System.Threading;
using PerfSurf.Counters;

namespace PerfSurf.Hubs
{
    public class PerfHub : Hub
    {
        public PerfHub()
        {
            StartCounterCollection();
        }
        
        public void Send(string message)
        {
            Clients.All.newMessage(Context.User.Identity.Name + " says " + message);
        }

        void StartCounterCollection()
        {
            var task = Task.Factory.StartNew(async () =>
            {
                var perfSerivce = new PerfCounterService();
                while (true)
                {
                    var results = perfSerivce.GetResults();
                    Clients.All.newCounters(results);
                    await Task.Delay(2000);
                }

            }, TaskCreationOptions.LongRunning);            
        }

        int _connections = 0;
    }
}