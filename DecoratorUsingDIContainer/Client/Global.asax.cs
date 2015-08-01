using System.Web.Mvc;
using System.Web.Routing;

namespace Client
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            //call the configuraton of the DI Container
            var diContainer = new DiContainer();
            diContainer.Start();

        }
    }
}
