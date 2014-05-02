using System.Data.Entity.Migrations;
using System.Web.Mvc;
using System.Web.Routing;
using LinkingTable.Migrations;

namespace LinkingTable
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var migrator = new DbMigrator(new Configuration());
            migrator.Update();
        }
    }
}
