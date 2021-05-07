using Internship.BL.Interfaces.Identity;
using Internship.Common.Dtos.Identity;
using Microsoft.Extensions.Logging;

namespace Internship.Web.Controllers.Identity
{
    public class HITsWorkersController : UserController<HITsWorkerDto>
    {
        public HITsWorkersController(
            ILogger<HITsWorkerDto> logger,
            IUserService<HITsWorkerDto> userService)
            : base(logger, userService)
        {
        }
    }
}
