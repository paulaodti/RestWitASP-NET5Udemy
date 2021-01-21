using Microsoft.AspNetCore.Mvc;
using RestWitASP_NET5Udemy.Business.Interfaces;
using RestWitASP_NET5Udemy.Data.VO;

namespace RestWitASP_NET5Udemy.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILoginBusiness _loginBusiness;

        public AuthController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] UserVO user)
        {
            if (user == null)
                return BadRequest("Invalid cliente request");

            var token = _loginBusiness.ValidateCredentials(user);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh([FromBody] TokenVO tokenVO)
        {
            if (tokenVO == null)
                return BadRequest("Invalid cliente request");

            var token = _loginBusiness.ValidateCredentials(tokenVO);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }

        [HttpPost]
        [Route("revoke")]
        public IActionResult Revoke()
        {
            var result = _loginBusiness.RevokeToken(User.Identity.Name);
            if (!result)
                return BadRequest("Invalid cliente request");
            return NoContent();
        }
    }
}
