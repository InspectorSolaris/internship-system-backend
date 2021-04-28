using Internship.DAL.Context;
using Internship.DAL.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Internship.Web.Configuration
{
    public static class ConfigurationDAL
    {
        public static void ConfigureDAL(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<InternshipDbContext>(options =>
            {
                options.UseNpgsql(configuration["ConnectionStrings:InternshipDbContext"]);
            });

            serviceCollection.AddIdentity<User, Role>(setup =>
            {
                setup.User.RequireUniqueEmail = true;

                setup.Password.RequireNonAlphanumeric = false;
                setup.Password.RequireLowercase = false;
                setup.Password.RequireUppercase = false;
                setup.Password.RequireDigit = false;
            });
        }
    }
}
