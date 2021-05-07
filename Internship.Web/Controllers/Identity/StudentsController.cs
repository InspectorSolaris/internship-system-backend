using Internship.BL.Interfaces.Identity;
using Internship.Common.Dtos.Identity;
using Microsoft.Extensions.Logging;

namespace Internship.Web.Controllers.Identity
{
    public class StudentsController : UserController<StudentDto>
    {
        public StudentsController(
            ILogger<StudentDto> logger,
            IUserService<StudentDto> userService)
            : base(logger, userService)
        {
        }
    }
}
