using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly string[] Users = new[]
        {
            "Gabriel", "Andrea", "Fernando"
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Users);
        }
    }
}
