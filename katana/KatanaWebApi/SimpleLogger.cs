using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Owin;

namespace KatanaWebApi
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class SimpleLogger
    {
        private readonly AppFunc _next;
        private readonly SimpleLoggerOptions _options;

        public SimpleLogger(AppFunc next, SimpleLoggerOptions options)
        {
            _next = next;
            _options = options;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            foreach (var key in _options.RequestKeys)
              {
                _options.Log(key, environment[key]);            
            }   

            await _next(environment);

            foreach (var key in _options.ResponseKeys)
            {
                _options.Log(key, environment[key]);
            }   
        }
        
    }

    public class SimpleLoggerOptions
    {
        public IList<string> RequestKeys { get; set; }
        public IList<string> ResponseKeys { get; set; }
        public Action<string, object> Log { get; set; }
    }

    public static class AppBuilderExtensions
    {
        public static IAppBuilder UseSimpleLogger(
            this IAppBuilder app, 
            SimpleLoggerOptions options)
        {
            return app.Use<SimpleLogger>(options);
        }
    }
}