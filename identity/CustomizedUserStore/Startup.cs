using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomizedUserStore.Startup))]
namespace CustomizedUserStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
