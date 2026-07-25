using Microsoft.AspNetCore.Identity;

namespace Microservices.Backend.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Names { get; set; }
    }
}
