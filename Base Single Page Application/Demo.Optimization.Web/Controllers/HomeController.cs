using System.Web.Mvc;

namespace Demo.Optimization.Web.Controllers
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

        //
        // GET: /Home/Dashboard
        public ActionResult Dashboard()
        {
            return PartialView();
        }

        //
        // GET: /Home/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        //
        // GET: /Home/Details
        public ActionResult Details()
        {
            return PartialView();
        }

        //
        // GET: /Home/List
        public ActionResult List()
        {
            return PartialView();
        }

    }
}
