using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PerfSurf.Models
{
    public class PerfDb : DbContext
    {
        public DbSet<PerfCounter> Counters { get; set; }
    }
}