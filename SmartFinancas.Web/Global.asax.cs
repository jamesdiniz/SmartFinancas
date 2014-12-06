using System.Web.Mvc;
using System.Web.Routing;
using SmartFinancas.Application.AutoMapper;

namespace SmartFinancas.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutoMapperConfig.RegisterMappings();
            AutofacConfig.Initialize();
        }
    }
}
