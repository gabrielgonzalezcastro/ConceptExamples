using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Demo.Optimization.Web
{
    /// <summary>
    /// Global application events.
    /// </summary>
    public class MvcApplication : HttpApplication
    {
        /// <summary>
        /// Event that occurs once on application startup.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}