using System;
using System.Web;
using System.Web.Configuration;

namespace Base.SinglePageApplication.Configuration
{
    /// <summary>
    /// Example of a Custom Module use for redirection without using the MVC route module.
    /// </summary>
    public class RedirectModule : IHttpModule
    {
        private HttpApplication _context;
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            _context = context;
            //Inject the redirection in the MapRequestHandler
            context.MapRequestHandler += RedirectUrls;
        }

        public void RedirectUrls(object src, EventArgs args)
        {
            RedirectSection section = (RedirectSection) WebConfigurationManager.GetWebApplicationSection("redirects");
            foreach (Redirect redirect in section.Redirects)
            {
                if(redirect.Old == _context.Request.RequestContext.HttpContext.Request.RawUrl)
                    _context.Response.Redirect(redirect.New);
            }
        }
    }
}