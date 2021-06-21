using Internship.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Internship.Web.Configuration
{
    public static class IdentityConfiguration
    {
        public static async Task Seed<TUser, TRole>(UserManager<TUser> userManager, RoleManager<TRole> roleManager, string role)
            where TUser : User, new()
            where TRole : Role, new()
        {
            var adminUser = await userManager.FindByNameAsync("Admin");

            if (adminUser == null)
            {
                await userManager.CreateAsync(new TUser()
                {
                    UserName = $"Admin{role}",
                    Email = "admin_email@mail.com"
                }, $"Password{role}");
            }

            var adminRole = await roleManager.FindByNameAsync("Admin");

            if (adminRole == null)
            {
                await roleManager.CreateAsync(new TRole()
                {
                    Name = "Admin"
                });
            }

            if (await roleManager.FindByNameAsync(role) == null)
            {
                await roleManager.CreateAsync(new TRole()
                {
                    Name = role
                });
            }

            adminUser = await userManager.FindByNameAsync($"Admin{role}");

            var adminUserRoles = await userManager.GetRolesAsync(adminUser);

            if (!adminUserRoles.Contains("Admin"))
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            if (!adminUserRoles.Contains(role))
            {
                await userManager.AddToRoleAsync(adminUser, role);
            }
        }
    }
}
