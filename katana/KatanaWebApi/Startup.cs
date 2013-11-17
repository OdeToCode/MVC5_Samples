using System;
using System.Diagnostics;
using System.Web.Http;
using Owin;

namespace KatanaWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var options = new WrappingOptions()
            {
                BeforeNext = (middleware, environment) =>
                    Debug.WriteLine("Calling into: " + middleware),
                AfterNext = (middleware, environment) =>
                    Debug.WriteLine("Coming back from: " + middleware),
            };

            app = new WrappingAppBuilder<WrappingLogger>(app, options);


            // ...
            InstallWebApi(app);
            InstallDefaultHandler(app); 
        }

        private static void InstallWebApi(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );

            app.UseWebApi(config);
        }

        private void InstallDefaultHandler(IAppBuilder app)
        {
            app.Run(ctx => ctx.Response.WriteAsync("Hello!"));
        }          
    }
}