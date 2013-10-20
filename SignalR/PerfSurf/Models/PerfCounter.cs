using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PerfSurf.Models
{
    public class PerfCounter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Instance { get; set; }
        public string Counter { get; set; }        
    }
}