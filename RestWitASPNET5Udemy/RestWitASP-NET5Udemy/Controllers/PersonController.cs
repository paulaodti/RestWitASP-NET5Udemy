using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWitASP_NET5Udemy.Model;
using RestWitASP_NET5Udemy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWitASP_NET5Udemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            var person = _personService.FindByID(id);
            if (person == null)
                return NotFound();
            return Ok(person);
            
        }

        [HttpPost]
        public ActionResult Post([FromBody] Person person)
        {
            if (person != null)
                return BadRequest();
            return Ok(_personService.Create(person));
        }

        [HttpPut]
        public ActionResult Put([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();
            return Ok(_personService.Update(person));
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
