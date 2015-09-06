using System.Web.Http.Filters;

namespace Base.SinglePageApplication.Filters
{

    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        //TODO: Implement Command exception on the Core project
        //public override void OnException(HttpActionExecutedContext actionExecutedContext)
        //{
        //    if (actionExecutedContext.Exception is CommandException)
        //    {
        //        var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
        //        {
        //            Content = new StringContent(JsonConvert.SerializeObject(actionExecutedContext.Exception,
        //                    PageConfiguration.GetDefaultJsonConfiguration())),
        //            ReasonPhrase = "Validation errors found"
        //        };

        //        throw new HttpResponseException(response);

        //    }
        //    base.OnException(actionExecutedContext);
        //}
    }
}