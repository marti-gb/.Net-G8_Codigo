using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCore_JWT.Identity.Data
{
    public class ApplicationDbContext(DbContextOptions options) : 
        IdentityDbContext<ApplicationUser>(options)
    {
    }
}
