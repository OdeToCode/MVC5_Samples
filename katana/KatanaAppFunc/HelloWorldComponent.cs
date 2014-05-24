using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace KatanaAppFunc
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class HelloWorldComponent
    {
        readonly AppFunc _next;
        readonly HelloWorldOptions _options;

        public HelloWorldComponent(AppFunc next, HelloWorldOptions options)
        {
            _next = next;
            _options = options;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var response = environment["owin.ResponseBody"] as Stream;
            using (var writer = new StreamWriter(response))
            {
                if (_options.IncludeTimestamp)
                {
                    await writer.WriteAsync(DateTime.Now.ToLongTimeString());
                }
                await writer.WriteAsync("Hello, " + _options.Name + "!");
            }
           
        }
    }
}