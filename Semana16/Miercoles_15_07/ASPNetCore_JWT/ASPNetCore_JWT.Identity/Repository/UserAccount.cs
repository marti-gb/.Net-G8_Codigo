using ASPNetCore_JWT.Identity.Data;
using Microsoft.AspNetCore.Identity;
using SearchClassLibrary.Contracts;
using SearchClassLibrary.Dto;

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

        public Task<ServiceReponse.LoginResponse> LoginAccount(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }
    }
}
