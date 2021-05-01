using Internship.DAL.Context;
using Internship.DAL.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Internship.Web.Configuration
{
    public static class ConfigurationDAL
    {
        public static void ConfigureDAL(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<InternshipDbContext>(options =>
            {
                const string connectionStringKeyHeroku = "DATABASE_URL";
                const string connectionStringKeyLocal = "ConnectionStrings:InternshipDbContext";

                var connectionString = string.Empty;

                if (configuration.GetSection(connectionStringKeyHeroku).Exists())
                {
                    var connectionStringUri = configuration[connectionStringKeyHeroku];

                    var uri = new Uri(connectionStringUri);

                    var userinfo = uri.UserInfo.Split(':');
                    
                    var host = uri.Host;
                    var port = uri.Port;
                    var database = uri.AbsolutePath[1..];
                    var username = userinfo[0];
                    var password = userinfo[1];

                    connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password};SSL Mode=Require;Trust Server Certificate=true;";
                }
                else
                {
                    connectionString = configuration[connectionStringKeyLocal];
                }

                options.UseNpgsql(connectionString);
            });

            serviceCollection.AddIdentity<User, Role>(setup =>
            {
                setup.User.RequireUniqueEmail = true;

                setup.Password.RequireNonAlphanumeric = false;
                setup.Password.RequireLowercase = false;
                setup.Password.RequireUppercase = false;
                setup.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<InternshipDbContext>();
        }
    }
}
