using System.Web.Mvc;

namespace Base.SinglePageApplication.Controllers
{
    /// <summary>
    /// Home controller used for the default serving of views to the application.
    /// </summary>
    public class HomeController : Controller
    {
        //
        // GET: /
        public ActionResult Index()
        {
            return View();
        }

        

    }
}
