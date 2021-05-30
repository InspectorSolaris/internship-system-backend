using Internship.BL.Interfaces.Common;
using Internship.Common.Dtos;
using Internship.Web.Controllers.Common;
using Microsoft.Extensions.Logging;

namespace Internship.Web.Controllers
{
    public class PriorityStudentsController : EntityController<PriorityStudentDto>
    {
        public PriorityStudentsController(
            ILogger<PriorityStudentDto> logger,
            IEntityService<PriorityStudentDto> entityService)
            : base(logger, entityService)
        {
        }
    }
}
