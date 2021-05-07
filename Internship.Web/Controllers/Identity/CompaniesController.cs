using Internship.BL.Interfaces.Identity;
using Internship.Common.Dtos.Identity;
using Microsoft.Extensions.Logging;

namespace Internship.Web.Controllers.Identity
{
    public class CompaniesController : UserController<CompanyDto>
    {
        public CompaniesController(
            ILogger<CompanyDto> logger,
            IUserService<CompanyDto> userService)
            : base(logger, userService)
        {
        }
    }
}
