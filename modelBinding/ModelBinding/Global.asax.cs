using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ModelBinding.Extensions;
using ModelBinding.Models;

namespace ModelBinding
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {            
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            // custom model binding
            //ModelBinders.Binders.Add(typeof(Account), new AccountModelBinder());
            //ModelBinders.Binders.Add(typeof(DateTime), new DateTimeModelBinder());
        }
    }
}
