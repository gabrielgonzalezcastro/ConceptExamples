using System;
using System.Configuration;
using System.Web;
using System.Web.Mvc;

namespace Base.SinglePageApplication.Filters
{
    //This Method Run before Hit the first Action Result of MVC Pages. It is use for Authentication
    [AttributeUsage(AttributeTargets.All)]
    public class PageAuthorizationAttribute : AuthorizeAttribute
    {
        //Can be added custom authentication logic here for the MVC pages
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authTokenCookie = httpContext.Request.Cookies["AuthToken"];
            if (authTokenCookie != null)
                return true;

            return false;

            //return base.AuthorizeCore(httpContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var authTokenCookie = filterContext.HttpContext.Request.Cookies["AuthToken"];
            var message = string.Empty;
            if (authTokenCookie != null)
            {
                message = "?message=Login Failed";
            }
            filterContext.Result = new RedirectResult(Uri.EscapeUriString(ConfigurationManager.AppSettings["demoApp.loginUrl"] + message));
        }
    }
}