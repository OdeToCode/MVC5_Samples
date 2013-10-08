using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomizedMemebershipModel.Startup))]
namespace CustomizedMemebershipModel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
