using Base.Business;
using System;
using System.Web.Http;
using System.Web.Http.Tracing;

namespace Base.SinglePageApplication.Controllers
{
    public class BaseController : ApiController
    {
        private readonly IApplicationFacade _applicationFacade;

        public BaseController(IApplicationFacade applicationFacade)
        {
            _applicationFacade = applicationFacade;
        }

        protected Guid GetGuidFromHttpRequestMessage()
        {
            var request = this.Request;
            var record = new TraceRecord(request, null, TraceLevel.Off);
            return record.RequestId == Guid.Empty ? new Guid() : record.RequestId;
        }

    }
}