using LayerProject.Data;
using LayerProject.Models;
using LayerProject.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LayerProject.DataAccess.Data.Initializer
{
    public class Initializer : IInitializarDB
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public Initializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        void IInitializarDB.Initializer()
        {
            try
            {
                if(_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
            }

            if (_db.Roles.Any(x => x.Name == Roles.Administrator)) return;

            _roleManager.CreateAsync(new IdentityRole(Roles.Administrator)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(Roles.Customer)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(Roles.User)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "gabriel@gmail.com",
                Email = "gabriel@gmail.com",
                Name = "Gabriel",
                EmailConfirmed = true,
            }, "Admin123@").GetAwaiter().GetResult();

            ApplicationUser user = _db.ApplicationUsers.Where(x => x.Email == "gabriel@gmail.com").FirstOrDefault();

            _userManager.AddToRoleAsync(user, Roles.Administrator).GetAwaiter().GetResult();
        }
    }
}
