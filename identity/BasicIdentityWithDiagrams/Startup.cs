using BasicIdentityWithDiagrams.Logging;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BasicIdentityWithDiagrams.Startup))]
namespace BasicIdentityWithDiagrams
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app = new AppBuilderLoggingWrapper(app);
            ConfigureAuth(app);
        }
    }
}
