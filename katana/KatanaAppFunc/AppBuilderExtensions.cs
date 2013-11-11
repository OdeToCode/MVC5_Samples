using Owin;

namespace KatanaAppFunc
{
    public static class AppBuilderExtensions
    {
        public static void UseHelloWorld(
            this IAppBuilder app, HelloWorldOptions options = null)
        {
            options = options ?? new HelloWorldOptions();
            app.Use<HelloWorldComponent>(options);
        }
    }
}