using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWitASP_NET5Udemy.Business.Interfaces;
using RestWitASP_NET5Udemy.Data.VO;
using RestWitASP_NET5Udemy.Hypermedia.Filters;

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
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Get(long id)
        {
            var person = _personBusiness.FindByID(id);
            if (person == null)
                return NotFound();
            return Ok(person);
            
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Post([FromBody] PersonVO person)
        {
            if (person == null)
                return BadRequest();
            return Ok(_personBusiness.Create(person));
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Put([FromBody] PersonVO person)
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
