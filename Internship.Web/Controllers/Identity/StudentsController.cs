using Internship.BL.Interfaces.Identity;
using Internship.Common.Dtos.Identity;
using Internship.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Internship.Web.Controllers.Identity
{
    public class StudentsController : UserController<Student, StudentDto>
    {
        public StudentsController(
            ILogger<StudentDto> logger,
            IUserService<StudentDto> userService,
            UserManager<Student> userManger)
            : base(logger, userService, userManger)
        {
        }
    }
}
