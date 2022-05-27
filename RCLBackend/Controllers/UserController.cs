using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RCLBackend.DTO;
using RCLBackend.Persistence.Entities;
using RCLBackend.Repositories.Abstract;
using RCLBackend.Services;

namespace RCLBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly AuthService _authService;
        private readonly IUserService _userService;

        public UserController(IUserRepository repository, AuthService authService, IUserService userService)
        {
            _repository = repository;
            _authService = authService;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] UserRegisterDTO request)
        {
            try
            {
                _userService.Register(request);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] UserLoginDTO request)
        {
            try
            {
                var user = _repository.GetUserByUserId(request.UserId);
                if (user == null)
                {
                    return BadRequest(new { message = "Invalid credentials" });
                }

                if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                {
                    return BadRequest(new { message = "Invalid credentials" });
                }
                
                var jwt = _authService.Generate(request.UserId);
                Response.Cookies.Append("jwt", jwt, new CookieOptions
                {
                    HttpOnly = true,
                });

                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("User")]
        public IActionResult User() 
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _authService.Verify(jwt);
                string userid = token.Issuer;
                var user = _repository.GetUserByUserId(userid);

                return Ok(user);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        [HttpPost("Logout")]
        public IActionResult Logout() 
        {
            try
            {
                Response.Cookies.Delete("jwt");
                return Ok(new 
                { 
                    message = "success"
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
