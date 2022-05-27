using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RCLBackend.DTO;
using RCLBackend.Persistence.Entities;

namespace RCLBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController()
        {

        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] UserRegisterDTO request)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] UserLoginDTO request)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
