using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RCLBackend.DTO;
using RCLBackend.Persistence.Entities;
using RCLBackend.Repositories.Abstract;
using RCLBackend.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RCLBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly AuthService _authService;
        private readonly IUserService _userService;
        private IConfiguration _configuration;

        public UserController(IUserRepository repository, AuthService authService, IUserService userService, IConfiguration configuration)
        {
            _repository = repository;
            _authService = authService;
            _userService = userService;
            _configuration = configuration;
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

                var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.UserId),
                        new Claim("DisplayName", user.FirstName),
                        new Claim("UserName", user.UserId),
                        new Claim("Email", user.EmailAddress),
                        new Claim("Role", user.UserRole)
                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: signIn);

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));

                //var jwt = _authService.Generate(request);
                //Response.Cookies.Append("jwt", jwt, new CookieOptions
                //{
                //    HttpOnly = true,
                //});
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

        [HttpGet("Test")]
        public IActionResult Test()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
