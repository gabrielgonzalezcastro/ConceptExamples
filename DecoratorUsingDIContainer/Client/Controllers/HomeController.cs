using DecoratorDesignPattern;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApplicationFacade _facade;

        public HomeController(IApplicationFacade facade)
        {
            _facade = facade;
        }

        // GET: Home
        public ActionResult Index()
        {
            var result = _facade.Sum(1, 1);
            return View(result);
        }
    }
}