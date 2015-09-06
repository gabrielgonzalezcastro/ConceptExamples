using Base.Business;
using System.Web.Http;
using Base.SinglePageApplication.Infrastructure;

namespace Base.SinglePageApplication.Controllers.api
{
    [RoutePrefix("public/api/v1/Book")]
    public class BookController : BaseController
    {
        private readonly IApplicationFacade _applicationFacade;

        public BookController(IApplicationFacade applicationFacade) : base (applicationFacade)
        {
            _applicationFacade = applicationFacade;
        }

        [HttpGet]
        public IHttpActionResult GetAllBooks()
        {
            var books = _applicationFacade.GetAllBooks();
            return Ok(books);
        }

        [Route("{bookId}/detail")]
        [HttpGet]
        public IHttpActionResult GetBook(int bookId)
        {
            var book = _applicationFacade.GetBook(bookId);
            return Ok(book);
        }

    }
}
