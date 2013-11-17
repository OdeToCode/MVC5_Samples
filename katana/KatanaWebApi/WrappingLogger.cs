using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatanaWebApi
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class WrappingLogger
    {
        private readonly AppFunc _next;
        private readonly WrappingOptions _options;
        private readonly string _middlewareDescription;

        public WrappingLogger(
            AppFunc next, 
            WrappingOptions options, 
            string middlewareDescription)
        {
            _next = next;
            _options = options;
            _middlewareDescription = middlewareDescription;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            _options.BeforeNext(_middlewareDescription, environment);
            await _next(environment);
            _options.AfterNext(_middlewareDescription, environment);
        }
    }
}