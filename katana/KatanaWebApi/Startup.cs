using System.Diagnostics;
using System.Web.Http;
using Owin;

namespace KatanaWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            InstallLogging(app);            
            InstallWebApi(app);
            InstallDefaultHandler(app); 
        }

        private void InstallLogging(IAppBuilder app)
        {
            var options = new SimpleLoggerOptions
            {
                Log = (key, value) => Debug.WriteLine("{0}:{1}", key, value),
                RequestKeys = new[] { "owin.RequestPath", "owin.RequestMethod"},
                ResponseKeys = new[] { "owin.ResponseStatusCode" }
            };
            app.UseSimpleLogger(options);
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