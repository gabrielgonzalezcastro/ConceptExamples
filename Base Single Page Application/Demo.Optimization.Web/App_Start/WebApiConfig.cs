using System.Web.Http;
using Base.SinglePageApplication.Filters;
using Base.SinglePageApplication.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Base.SinglePageApplication.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: PageConfiguration.WebApiRoutePrefix + "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Exception treatment
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            //config.Filters.Add(new ApiExceptionFilter);

            //Logging
            //TODO: Implement TracerWriter On Core Project
            //config.Services.Replace(typeof(System.Web.Http.Tracing.ITraceWriter),new TracerWriter);
            
            //Serialization in camelCase for JS
            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //API Authentication
            config.Filters.Add(new ApiAuthorizeAttribute());

            //Token renovation
            config.MessageHandlers.Add(new TokenRenovationHandler());
        }
    }
}