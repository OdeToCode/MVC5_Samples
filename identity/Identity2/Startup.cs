using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Identity2.Startup))]
namespace Identity2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
