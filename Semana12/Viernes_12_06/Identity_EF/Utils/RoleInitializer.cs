using Identity_EF.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity_EF.Utils
{
    public static class RoleInitializer
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

            string[] roleNames = { "Admin", "User", "Client" };

            foreach(var name in roleNames)
            {
                var roleExists = await roleManager.RoleExistsAsync(name);

                if (!roleExists)
                {
                    await roleManager.CreateAsync(new IdentityRole(name));
                }
            }

            //Crear un usuario Admin
            string adminEmail = "admin@gmail.com";
            string password = "Admin123";
            var newUser = new AppUser();

            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if(adminUser == null)
            {
                newUser = new AppUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    Nombres = "Administrador",
                    Direccion = "Direccion test"
                };
            }

            var result = await userManager.CreateAsync(newUser, password);
        }
    }
}
