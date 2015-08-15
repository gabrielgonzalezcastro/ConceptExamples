using System.Web.Mvc;
using Xml_Serialization_And_Deserialization.Serializer;

namespace Xml_Serialization_And_Deserialization.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Get the instance that perform the deserialization.
            var securityConfiguration = DependencyResolver.Current.GetService<SecurityConfiguration>();
            return View();
        }
    }
}