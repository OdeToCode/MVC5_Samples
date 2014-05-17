﻿using System.Diagnostics;

namespace PerfSurf.Counters
{
    public class PerfCounterWrapper
    {
        public PerfCounterWrapper(string name, string category, string counter, string instance = "")
        {
            Name = name;
            _counter = new PerformanceCounter(category, counter, instance, readOnly: true);
        }

        public string Name { get; protected set; }
        public float Value
        {
            get
            {
                return _counter.NextValue();
            }
        }

        PerformanceCounter _counter;
    }
}