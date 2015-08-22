using System;
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
        //
        // GET: /
        public ActionResult Index()
        {
            try
            {
                //Generate the Token and add it to a cookie
                string windowUsername = HttpContext.User.Identity.Name;
                string token = TokenManager.CreateJwtToken(windowUsername, "role_Guest");
                var userCookie = new HttpCookie("AuthToken", token);
                userCookie.Expires.AddDays(1);
                HttpContext.Response.Cookies.Add(userCookie);
                }
            catch (Exception ex)
            {
                throw new SecurityException("Error Generating the Token");
            }

            return View();
        }

        


           
       

        

    }
}
