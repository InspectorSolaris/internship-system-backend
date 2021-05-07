using Internship.BL.Interfaces.Identity;
using Internship.BL.Services.Identity;
using Internship.Common.Dtos.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Internship.Web.Configuration
{
    public static class ConfigurationBL
    {
        public static void ConfigureBL(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IUserService<StudentDto>, StudentService>();
            serviceCollection.AddScoped<IUserService<HITsWorkerDto>, HITsWorkerService>();
            serviceCollection.AddScoped<IUserService<CompanyDto>, CompanyService>();
        }
    }
}
