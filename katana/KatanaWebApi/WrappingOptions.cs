using System;
using System.Collections;
using System.Collections.Generic;

namespace KatanaWebApi
{
    using LogFunc = Action<object, IDictionary<string, object>>;

    public class WrappingOptions
    { 
        public LogFunc BeforeNext { get; set; }
        public LogFunc AfterNext { get; set; }
    }
}