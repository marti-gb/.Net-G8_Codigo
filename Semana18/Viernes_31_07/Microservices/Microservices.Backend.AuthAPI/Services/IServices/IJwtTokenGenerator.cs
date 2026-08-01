using Microservices.Backend.AuthAPI.Models;

namespace Microservices.Backend.AuthAPI.Services.IServices
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
