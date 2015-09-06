using Base.Business;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;

namespace Base.SinglePageApplication.App_Start
{
    public class DiContainer
    {
        public void Start()
        {
            var container = new Container();
            
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            RegisterTypes(container);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }

        private void RegisterTypes(Container container)
        {
            //Standard Implementation
            container.Register<IApplicationFacade, ApplicationFacade>();
        }
    }
}