using System;
using System.Collections.Generic;
using Owin;

namespace BasicIdentityWithDiagrams.Logging
{
    public class AppBuilderLoggingWrapper : IAppBuilder
    {
        private readonly IAppBuilder _inner;

        public AppBuilderLoggingWrapper(IAppBuilder inner)
        {
            _inner = inner;
        }

        public IAppBuilder Use(object middleware, params object[] args)
        {
            _inner.Use<LoggingMiddleware>(middleware);
            return _inner.Use(middleware, args);
        }

        public object Build(Type returnType)
        {
            return _inner.Build(returnType);
        }

        public IAppBuilder New()
        {
            return _inner.New();
        }

        public IDictionary<string, object> Properties
        {
            get
            {
                return _inner.Properties;
            }
        }
    }
}