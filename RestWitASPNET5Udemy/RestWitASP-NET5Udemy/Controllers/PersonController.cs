using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWitASP_NET5Udemy.Business;
using RestWitASP_NET5Udemy.Model;

namespace RestWitASP_NET5Udemy.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private IPersonBusiness _personBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _personBusiness = personBusiness;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            var person = _personBusiness.FindByID(id);
            if (person == null)
                return NotFound();
            return Ok(person);
            
        }

        [HttpPost]
        public ActionResult Post([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();
            return Ok(_personBusiness.Create(person));
        }

        [HttpPut]
        public ActionResult Put([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();
            return Ok(_personBusiness.Update(person));
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
