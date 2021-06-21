using Internship.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Internship.Web.Configuration
{
    public static class IdentityConfiguration
    {
        public static async Task Seed<TUser, TRole>(UserManager<TUser> userManager, RoleManager<TRole> roleManager, string namePostfix)
            where TUser : User, new()
            where TRole : Role, new()
        {
            var adminUser = await userManager.FindByNameAsync("Admin");

            if (adminUser == null)
            {
                await userManager.CreateAsync(new TUser()
                {
                    UserName = $"Admin{namePostfix}",
                    Email = "admin_email@mail.com"
                }, $"Password{namePostfix}");
            }

            var adminRole = await roleManager.FindByNameAsync("Admin");

            if (adminRole == null)
            {
                await roleManager.CreateAsync(new TRole()
                {
                    Name = "Admin"
                });
            }

            adminUser = await userManager.FindByNameAsync($"Admin{namePostfix}");

            var adminUserRoles = await userManager.GetRolesAsync(adminUser);

            if (!adminUserRoles.Contains("Admin"))
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
