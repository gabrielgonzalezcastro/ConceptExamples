using System.IO;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using Xml_Serialization_And_Deserialization.Serializer;

namespace Xml_Serialization_And_Deserialization.App_Start
{
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
            //Configuration
            container.RegisterSingle<SecurityConfiguration>(() =>
            {
                var pathFile = HttpContext.Current.Server.MapPath(@"SecurityConfiguration.xml");
                var config =
                    XmlSerializationHelper.XmlSerializationHelper.Deserialize<SecurityConfiguration>(
                        File.ReadAllText(pathFile));
                return config;
            });

        }
    }
}