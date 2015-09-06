using System.Web.Http;
using Newtonsoft.Json;

namespace Base.SinglePageApplication.Infrastructure
{
    public class PageConfiguration
    {
        public string Token { get; set; }
        public string ApplicationName { get; set; }
        public string ApplicationVersion { get; set; }
        public JsonSerializerSettings JsonSettings { get; set; }
        public string DefaultPath { get; set; }
        public string User { get; set; }

        public static JsonSerializerSettings GetDefaultJsonConfiguration()
        {
            return GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
        }
    }
}