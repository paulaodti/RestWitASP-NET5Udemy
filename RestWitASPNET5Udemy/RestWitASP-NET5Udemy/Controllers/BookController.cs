using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWitASP_NET5Udemy.Business.Interfaces;
using RestWitASP_NET5Udemy.Data.VO;

namespace RestWitASP_NET5Udemy.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private IBookBusiness _bookBusiness;

        public BookController(ILogger<BookController> logger, IBookBusiness bookBusiness)
        {
            _logger = logger;
            _bookBusiness = bookBusiness;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            var book = _bookBusiness.FindByID(id);
            if (book == null)
                return NotFound();
            return Ok(book);

        }

        [HttpPost]
        public ActionResult Post([FromBody] BookVO book)
        {
            if (book == null)
                return BadRequest();
            return Ok(_bookBusiness.Create(book));
        }

        [HttpPut]
        public ActionResult Put([FromBody] BookVO book)
        {
            if (book == null)
                return BadRequest();
            return Ok(_bookBusiness.Update(book));
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            _bookBusiness.Delete(id);
            return NoContent();
        }
    }
}
