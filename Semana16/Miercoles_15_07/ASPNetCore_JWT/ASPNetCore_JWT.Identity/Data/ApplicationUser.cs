using Microsoft.AspNetCore.Identity;

namespace ASPNetCore_JWT.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
