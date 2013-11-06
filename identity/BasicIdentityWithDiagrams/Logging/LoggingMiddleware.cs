using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BasicIdentityWithDiagrams.Logging
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class LoggingMiddleware
    {
        private readonly AppFunc _next;
        private readonly string _description;

        public LoggingMiddleware(AppFunc next, object middleware)
        {
            _next = next;
            var type = middleware as Type ?? middleware.GetType();
            _description = type.Name;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            Debug.WriteLine("Call to" + _description);
            await _next(environment);
            Debug.WriteLine("Back from " + _description);
        }
    }
}