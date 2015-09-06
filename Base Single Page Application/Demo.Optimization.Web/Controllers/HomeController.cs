using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Security;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Base.SinglePageApplication.Infrastructure;

namespace Base.SinglePageApplication.Controllers
{
    /// <summary>
    /// Home controller used for the default serving of views to the application.
    /// </summary>
    public class HomeController : Controller
    {
        //User: acer\Mediaworld
        // GET: /
        public ActionResult Index()
        {
            string token;
            try
            {
                //Generate the Token
                string windowUsername = HttpContext.User.Identity.Name;
                //token = TokenManager.CreateJwtToken(windowUsername, "role_Guest","demoApp");
            }
            catch (Exception ex)
            {
                throw new SecurityException("Error Generating the Token");
            }

            var pageConfiguration = new PageConfiguration
            {
                ApplicationName = "Books Online",
                ApplicationVersion = Assembly.GetAssembly(typeof(HomeController)).GetName().Version.ToString(),
                JsonSettings = PageConfiguration.GetDefaultJsonConfiguration(),
                User = User.Identity.Name,
                DefaultPath = "/Home",
                Token = GetTokenAndDestroyCookie()
            };

            pageConfiguration.AngularRoutes = GetAngularRoutes();

            return View(pageConfiguration);
        }

        [AllowAnonymous]
        public ActionResult Login(string message)
        {
            var pageConfiguration = new PageConfiguration
            {
                ApplicationName = "Books Online",
                ApplicationVersion = Assembly.GetAssembly(typeof(HomeController)).GetName().Version.ToString(),
                JsonSettings = PageConfiguration.GetDefaultJsonConfiguration(),
                User = User.Identity.Name,
                DefaultPath = "/Home",                
            };

            ViewBag.Message = message;
            ViewBag.UserName = HttpContext.User.Identity.Name;
            ViewBag.IsDisabled = "true";
            if(string.IsNullOrEmpty(ViewBag.UserName))
                ViewBag.IsDisabled = "false";

            return View(pageConfiguration);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult LoginPost(FormCollection form)
        {
            var userName = HttpContext.User.Identity.Name;
            var token = TokenManager.CreateJwtToken(userName, "role_Guest", "demoApp");
            var authCookie = new HttpCookie("AuthToken", token);
            authCookie.Expires = DateTime.UtcNow.AddMinutes(5);
            Response.AppendCookie(authCookie);
            return RedirectToAction("Index");
        }

        


        private List<AngularRoute> GetAngularRoutes()
        {
            return new List<AngularRoute>
            {
                new AngularRoute
                {
                    Url = "/Home",
                    Controller = "homeController",
                    Template = "/AngularViews/Dashboard.html?v="
                },
                new AngularRoute
                {
                    Url = "/Books",
                    Controller = "listController",
                    Template = "/AngularViews/List.html?v="
                },
                new AngularRoute
                {
                    Url = "/BookDetails/:id",
                    Controller = "detailsController",
                    Template = "/AngularViews/Details.html?v="
                },
                new AngularRoute
                {
                    Url = "/BookCreate",
                    Controller = "createController",
                    Template = "/AngularViews/Create.html?v="
                }
            };
        }

        private string GetTokenAndDestroyCookie()
        {
            string token = string.Empty;

             var authTokenCookie = HttpContext.Request.Cookies["AuthToken"];
            if (authTokenCookie != null)
            {
                token = authTokenCookie.Value;
                HttpContext.Request.Cookies.Remove("AuthToken");
            }

            return token;
        }
    }
}
