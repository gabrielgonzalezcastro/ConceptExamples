using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Base.SinglePageApplication.Infrastructure
{
    /// <summary>
    /// This Method Run After the ApiAuthorizeAttribute and the execution of the endpoint called. It add a brand new 
    /// token to a header on the response. This header is catch by restangular and added by angular.
    /// </summary>
    public class TokenRenovationHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //Pre-process
            var response = await base.SendAsync(request, cancellationToken);
            if (request.Headers.GetValues("AuthToken").FirstOrDefault() != null)
            {
                var token = TokenManager.CreateJwtToken(HttpContext.Current.User.Identity.Name, "role_Guest", "demoApp");
                response.Headers.Remove("AuthToken");
                response.Headers.Add("AuthToken",token);
            }
            
            //Post-process
            return response;
        }
    }
}