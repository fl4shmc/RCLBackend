using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RCLBackend.Services;
using RCLBackend.Services.Abstract;

namespace RCLBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        private readonly IWriterService _writerService;

        public WriterController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        [HttpGet("GetWriters")]
        public IActionResult GetWriters(string userid, string? searchQuery)
        {
            try
            {
                var writers = _writerService.GetWriters(userid, searchQuery);
                return Ok(writers);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetWriterPosts")]
        public IActionResult GetWriterPosts(string userid)
        {
            try
            {
                var writerPosts = _writerService.GetWriterPosts(userid);
                return Ok(writerPosts);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
