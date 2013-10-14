using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Library.Web.Startup))]
namespace Library.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
