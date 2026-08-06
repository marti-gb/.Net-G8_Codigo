using Microservices.Backend.AuthAPI.Data;
using Microservices.Backend.AuthAPI.Models;
using Microservices.Backend.AuthAPI.Models.Dto;
using Microservices.Backend.AuthAPI.Services.IServices;
using Microsoft.AspNetCore.Identity;

namespace Microservices.Backend.AuthAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(ApplicationDbContext db,
            UserManager<ApplicationUser> usermanager,
            RoleManager<IdentityRole> rolemanager,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _db = db;
            _usermanager = usermanager;
            _rolemanager = rolemanager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = registrationRequestDto.Email,
                Email = registrationRequestDto.Email,
                NormalizedEmail = registrationRequestDto.Email.ToUpper(),
                Names = registrationRequestDto.Name,
                PhoneNumber = registrationRequestDto.PhoneNumber
            };

            try
            {
                var result = await _usermanager.CreateAsync(user, registrationRequestDto.Password);
                if (result.Succeeded)
                {
                    var userToReturn = _db.ApplicationUsers.FirstOrDefault(x => x.UserName == registrationRequestDto.Email);
                    UserDto userDto = new UserDto()
                    {
                        Email = userToReturn.Email,
                        Id = userToReturn.Id,
                        Name = userToReturn.Names,
                        PhoneNumber = userToReturn.PhoneNumber
                    };

                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault()!.Description;
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(x => x.UserName.ToLower() == loginRequestDto.Username.ToLower());
            var isValid = await _usermanager.CheckPasswordAsync(user, loginRequestDto.Password);
            if (user == null || !isValid)
            {
                return new LoginResponseDto()
                {
                    User = null,
                    Token = ""
                };
            }

            var roles = await _usermanager.GetRolesAsync(user);
            var token = _jwtTokenGenerator.GenerateToken(user, roles);

            UserDto userDto = new UserDto
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.Names,
                PhoneNumber = user.PhoneNumber
            };

            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                User = userDto,
                Token = token
            };

            return loginResponseDto;

        }
        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(x => x.UserName.ToLower() == email.ToLower());
            if (user != null)
            {
                if (!_rolemanager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    _rolemanager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                }

                await _usermanager.AddToRoleAsync(user, roleName);
                return true;
            }
            return false;

        }

    }
}
