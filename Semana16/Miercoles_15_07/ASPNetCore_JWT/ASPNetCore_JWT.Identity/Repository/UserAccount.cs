using ASPNetCore_JWT.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SearchClassLibrary.Contracts;
using SearchClassLibrary.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static SearchClassLibrary.Dto.ServiceReponse;

namespace ASPNetCore_JWT.Identity.Repository
{
    public class UserAccount : IUserAccount
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public UserAccount(UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<ServiceReponse.GeneralResponse> CreateAccount(UserDto userDto)
        {
            if (userDto == null) 
                return new ServiceReponse.GeneralResponse(false, "EL modelo esta vacio");

            var newUser = new ApplicationUser()
            {
                Name = userDto.Name,
                Email = userDto.Email,
                PasswordHash = userDto.Password,
                UserName = userDto.Email
            };

            var user = await _userManager.FindByEmailAsync(newUser.Email);
            if (user is not null)
                return new ServiceReponse.GeneralResponse(false, "Ese correo ya se encuentra en uso.");


            var createdUser = await _userManager.CreateAsync(newUser, userDto.Password);
            if (!createdUser.Succeeded)
                return new ServiceReponse.GeneralResponse(false, "Ups, se encontro un error");

            var checkAdmin = await _roleManager.FindByNameAsync("Admin");
            if(checkAdmin is null)
            {
                await _roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
                await _userManager.AddToRoleAsync(newUser, "Admin");

                return new ServiceReponse.GeneralResponse(true, "Usuario con rol administrador " +userDto.Name+" creado con exito");
            }
            else
            {
                var chackUser = await _roleManager.FindByNameAsync("User");
                if (chackUser is null)
                {
                    await _roleManager.CreateAsync(new IdentityRole() { Name = "User" });
                }
                await _userManager.AddToRoleAsync(newUser, "User");

                return new ServiceReponse.GeneralResponse(true, "Usuario con rol user " + userDto.Name + " creado con exito");
            }
        }

        public async Task<ServiceReponse.LoginResponse> LoginAccount(LoginDto loginDto)
        {
            if(loginDto == null)
                return new LoginResponse(false, string.Empty, "El login no puede estar vacio");

            var getUser = await _userManager.FindByEmailAsync(loginDto.Email);
            if (getUser is null)
                return new LoginResponse(false, null, "El usuario no existe");

            bool checkUserPassword = await _userManager.CheckPasswordAsync(getUser, loginDto.Password);
            if (!checkUserPassword)
                return new LoginResponse(false, string.Empty, "Email o contraseña invalida");

            var getRoleInUser = await _userManager.GetRolesAsync(getUser);

            var userSession = new UserSession(getUser.Id, getUser.Name, getUser.Email, getRoleInUser.First());

            string token = GenerateToken(userSession);

            return new LoginResponse(true, token, "Login completado, token generado");


        }

        private string GenerateToken(UserSession userSession)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userSession.Id),
                new Claim(ClaimTypes.Name, userSession.Name),
                new Claim(ClaimTypes.Email, userSession.Email),
                new Claim(ClaimTypes.Role, userSession.Role),
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
