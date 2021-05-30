using Internship.BL.Interfaces.Common;
using Internship.Common.Dtos;
using Internship.Web.Controllers.Common;
using Microsoft.Extensions.Logging;

namespace Internship.Web.Controllers
{
    public class SubjectsController : EntityController<SubjectDto>
    {
        public SubjectsController(
            ILogger<SubjectDto> logger,
            IEntityService<SubjectDto> entityService)
            : base(logger, entityService)
        {
        }
    }
}
