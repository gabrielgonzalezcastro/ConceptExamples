using System;
using System.Configuration;
using System.Reflection;
using System.Web.Mvc;
using DecoratorDesignPattern;
using SimpleInjector;
using SimpleInjector.Extensions;
using SimpleInjector.Integration.Web.Mvc;

namespace Client
{
    /// <summary>
    /// Class that contains the configuration of the DI Container
    /// </summary>
    public class DiContainer
    {
        public void Start()
        {
            // Create the container as usual.
            var container = new Container();

            RegisterTypes(container);

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            // This is an extension method from the integration package as well.
            container.RegisterMvcIntegratedFilterProvider();

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private void RegisterTypes(Container container)
        {
            // Register your types, for instance:
            //container.Register<IUserRepository, SqlUserRepository>();

            //Standard Implementation
            container.Register<IApplicationFacade, ApplicationFacade>();

            //Register Decorator (depend on a key in the web.config file)
            bool addLogDecorator = Convert.ToBoolean(ConfigurationManager.AppSettings["AddLogDecorator"]);
            if (addLogDecorator)
            {
                container.RegisterDecorator(typeof(IApplicationFacade),
                      typeof(LogApplicationFacade));    
            }

            //Note: If the key in the web.config is false the decorator is not registered and the ApplicationFacade 
            //concrete class will be called directly without passing for the LogApplicationFacade. If the LogApplicationFacade
            //is register, this class will be called instead of call the applicationFacade directly. This way we can add 
            //as many layers as we want (adding functionality)
            

            //////////////////////////////
            //Adding second decorator
            bool addValidationDecorator = Convert.ToBoolean(ConfigurationManager.AppSettings["AddValidationDecorator"]);
            if (addValidationDecorator)
            {
                container.RegisterDecorator(typeof(IApplicationFacade),
                      typeof(ValidationApplicationFacade));
            }
            

            
        }

    }
}