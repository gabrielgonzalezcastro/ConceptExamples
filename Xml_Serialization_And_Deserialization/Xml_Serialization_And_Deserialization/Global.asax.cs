using System.Web.Mvc;
using System.Web.Routing;
using Xml_Serialization_And_Deserialization.App_Start;

namespace Xml_Serialization_And_Deserialization
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
