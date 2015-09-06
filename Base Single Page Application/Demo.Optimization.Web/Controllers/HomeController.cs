using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Security;
using System.Web;
using System.Web.Mvc;
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
                token = TokenManager.CreateJwtToken(windowUsername, "role_Guest","demoApp");
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
                Token = token
            };

            pageConfiguration.AngularRoutes = GetAngularRoutes();
            
       
            //TODO: 2.- USE THE TOKEN TO ADDED IN A HEADER CALLED 'AuthToken' IN EACH REQUEST USING RESTANGULAR 
            //TODO: 3.- VERIFY THAT THE AUTHENTICATION OF THE WEB API WORKS (ApiAuthorizeAttribute)

            return View(pageConfiguration);
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
                    Url = "/BookDetails",
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
    }
}
