using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DDDPizza.Mvc.App_Start;

namespace DDDPizza.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            MongoConfig.Register();
            AutoFacConfig.Register();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();


        }
    }
}
