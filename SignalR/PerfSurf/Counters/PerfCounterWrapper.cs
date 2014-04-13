using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PerfSurf.Counters
{
    public class PerfCounterWrapper
    {
        public PerfCounterWrapper(string name, string category, string counter, string instance = "")
        {
            try
            {
                Name = name;
                _counter = new PerformanceCounter(category, counter, instance, readOnly: true);
            }
            catch (Exception ex)
            {
                
            }
        }

        public string Name { get; protected set; }
        public float Value
        {
            get
            {
                if (_counter != null)
                {
                    return _counter.NextValue();
                }
                return _rand.Next(0, 100);
            }
        }

        private static Random _rand = new Random();
        PerformanceCounter _counter;
    }
}