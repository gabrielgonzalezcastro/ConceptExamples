using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using Base.Core.Exception;
using Base.SinglePageApplication.Infrastructure;
using Newtonsoft.Json;

namespace Base.SinglePageApplication.Filters
{

    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is CommandException)
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(actionExecutedContext.Exception,
                            PageConfiguration.GetDefaultJsonConfiguration())),
                    ReasonPhrase = "Validation errors found"
                };

                throw new HttpResponseException(response);

            }
            base.OnException(actionExecutedContext);
        }
    }
}