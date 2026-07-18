using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IConfiguration _config) : ControllerBase
    {
        private static ConcurrentDictionary<string, string> UserData { get; set; } =
            new ConcurrentDictionary<string, string>();

        [HttpPost("login/{email}/{password}")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var getEmail = UserData!.Keys.Where(x => x.Equals(email)).FirstOrDefault();
            if (!string.IsNullOrEmpty(getEmail))
            {
                UserData.TryGetValue(getEmail, out string? dbPassword);
                if (!Equals(dbPassword, password))
                {
                    return BadRequest("Contraseña o email invalidos");
                }
                string jwtToken = GenerateToken(getEmail);
                return Ok(jwtToken);
            }
            return NotFound("Email no encontrado");
        }

        private string GenerateToken(string getEmail)
        {
            var key = Encoding.UTF8.GetBytes(_config["Authentication:Key"]!);
            var securityKey = new SymmetricSecurityKey(key);

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, getEmail),
            };

            var token = new JwtSecurityToken(
                issuer: _config["Authentication:Issuer"],
                audience: _config["Authentication:Audience"],
                claims: claims,
                expires: null,
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("register/{email}/{password}")]
        public async Task<IActionResult> Register(string email, string password)
        {
            var getEmail = UserData!.Keys.Where(x => x.Equals(email)).FirstOrDefault();
            if (!string.IsNullOrEmpty(getEmail))
            {
                return BadRequest("User ya se encuentra en uso");
            }
            UserData[email] = password;
            return Ok("Usuario creado con exito");
        }
    }
    
}
