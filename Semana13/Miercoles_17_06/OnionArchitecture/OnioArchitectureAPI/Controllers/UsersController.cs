using DomainLayer.Dtos;
using DomainLayer.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OnioArchitectureAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _user;
        public UsersController(IUser user)
        {
            _user = user;
        }

        [HttpGet("Users")]
        public IActionResult GetAkkUsers()
        {
            var response = _user.GetListUsers();
            return Ok(response);
        }

        [HttpGet]
        [Route("GetUserById")]
        public IActionResult GetUserById(int id)
        {
            return Ok(_user.GetUserById(id));
        }

        [HttpPost]
        public IActionResult AddUser(UserDto userDto)
        {
            var user = _user.AddUser(userDto);
            return Ok(user);
        }

        [HttpPut]
        public IActionResult UpdateUser(UserDto userDto)
        {
            return Ok(_user.UpdateUser(userDto));
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            return Ok(_user.DeleteUser(id));
        }

    }
}
