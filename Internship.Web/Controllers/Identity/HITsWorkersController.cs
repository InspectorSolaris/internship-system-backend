using Internship.BL.Interfaces.Identity;
using Internship.Common.Dtos.Identity;
using Internship.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Internship.Web.Controllers.Identity
{
    public class HITsWorkersController : UserController<HITsWorker, HITsWorkerDto>
    {
        public HITsWorkersController(
            ILogger<HITsWorkerDto> logger,
            IUserService<HITsWorkerDto> userService,
            UserManager<HITsWorker> userManager)
            : base(logger, userService, userManager)
        {
        }
    }
}
