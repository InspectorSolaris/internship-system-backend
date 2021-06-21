using Internship.BL.Interfaces.Identity;
using Internship.Common.Dtos.Identity;
using Internship.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Internship.Web.Controllers.Identity
{
    public class CompaniesController : UserController<Company, CompanyDto>
    {
        public CompaniesController(
            ILogger<CompanyDto> logger,
            IUserService<CompanyDto> userService,
            UserManager<Company> userManager)
            : base(logger, userService, userManager)
        {
        }
    }
}
