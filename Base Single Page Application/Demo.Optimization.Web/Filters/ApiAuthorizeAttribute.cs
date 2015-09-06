using System.Collections.Generic;
using Base.SinglePageApplication.Infrastructure;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Base.SinglePageApplication.Filters
{
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        //This method will run before execute a endpoint in the web.api.
        //Custom Authentication for the Web API : This method will verify that the request made has a valid Token
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

            IEnumerable<string> values;
            if (actionContext.Request.Headers.TryGetValues("AuthToken", out values) && values.FirstOrDefault() != null)
            {
                bool isAuthenticated = true;

                // get the token from header
                string authenticationToken = Convert.ToString(actionContext.Request.Headers.GetValues("AuthToken").FirstOrDefault());

                try
                {
                    //Verify the token
                    TokenManager.ValidateJwtToken(authenticationToken, "demoApp");
                }
                catch (Exception ex)
                {
                    isAuthenticated = false;
                }

                HttpContext.Current.Response.AddHeader("AuthToken", authenticationToken);

                if (!isAuthenticated)
                {
                    //If the token passed is invalid
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                    actionContext.Response.ReasonPhrase = "Invalid Token";
                    return;
                }

                //If the token is valid
                HttpContext.Current.Response.AddHeader("AuthToken", authenticationToken);
                HttpContext.Current.Response.AddHeader("AuthStatus", "Authorized");
                return;
            }

            //If the request does not have a Token
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            actionContext.Response.ReasonPhrase = "Token does not Provide";
        }
    }
}