using Internship.BL.Interfaces.Identity;
using Internship.Common.Dtos.Identity;
using Internship.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Internship.Web.Controllers.Identity
{
    public class CompaniesController : UserController<Company, CompanyDto>
    {
        public CompaniesController(
            IMemoryCache cache,
            ILogger<CompanyDto> logger,
            IUserService<CompanyDto> userService,
            UserManager<Company> userManager)
            : base(cache, logger, userService, userManager)
        {
        }
    }
}
