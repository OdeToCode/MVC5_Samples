using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using PerfSurf.Models;

namespace PerfSurf.Hubs
{
    public class PerfHub : Hub
    {
        PerfDb db = new PerfDb();

        public dynamic GetCounters()
        {
            var model = db.Counters.Select(c => new { id = c.Id, name = c.Name });
            return model;
        }

        public void Hello(string name)
        {
            Clients.All.hello(name + " says hello!");
        }
    }
}