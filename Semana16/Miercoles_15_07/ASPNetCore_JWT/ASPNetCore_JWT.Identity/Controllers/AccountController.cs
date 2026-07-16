using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchClassLibrary.Contracts;
using SearchClassLibrary.Dto;

namespace ASPNetCore_JWT.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserAccount _userAccount;
        public AccountController(IUserAccount userAccount)
        {
            _userAccount = userAccount;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            var response = await _userAccount.CreateAccount(userDto);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var response = await _userAccount.LoginAccount(loginDto);
            return Ok(response);
        }
    }
}
