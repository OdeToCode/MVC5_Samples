using System;
using System.Collections.Generic;
using Owin;

namespace KatanaWebApi
{
    public class WrappingAppBuilder<TWrapper> : IAppBuilder
    {
        private readonly IAppBuilder _inner;
        private readonly object _wrappingOptions;

        public WrappingAppBuilder(IAppBuilder inner, object wrappingOptions)
        {
            _inner = inner;
            _wrappingOptions = wrappingOptions;
        }

        public IAppBuilder Use(object middleware, params object[] args)
        {
            _inner.Use(typeof (TWrapper), _wrappingOptions, GetDescription(middleware));
            return _inner.Use(middleware, args);
        }

        private string GetDescription(object middleware)
        {
            var type = middleware as Type ?? middleware.GetType();
            return type.Name;
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