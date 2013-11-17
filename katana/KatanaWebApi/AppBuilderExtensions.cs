using Owin;

namespace KatanaWebApi
{
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