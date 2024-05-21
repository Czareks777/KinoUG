using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KinoUG.Server.Models
{
    public class SeedAccountAdmin
    {
        public static async Task SeedAdminUser(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Check if the Admin role exists
            if (!await roleManager.RoleExistsAsync(Roles.Admin))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
            }

            // Check if there is any user with Admin role
            var adminUsers = await userManager.GetUsersInRoleAsync(Roles.Admin);
            if (adminUsers.Any())
            {
                return; // Admin user already exists, do nothing
            }

            // Create a new Admin user
            var adminUser = new User
            {
                UserName = "admin@example.com",
                Email = "admin@admin.com",
                Name = "Admin",
                Surname = "Admin"
            };
            
            var result = await userManager.CreateAsync(adminUser, "Admin123");

            //admin@admin.com
            //Admin123

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, Roles.Admin);
            }
            else
            {
                // Handle the case where the user could not be created
                throw new Exception("Failed to create the admin user");
            }

            
        }
    }
}
