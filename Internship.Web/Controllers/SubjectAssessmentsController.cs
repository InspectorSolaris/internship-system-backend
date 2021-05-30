using Internship.BL.Interfaces.Common;
using Internship.Common.Dtos;
using Internship.Web.Controllers.Common;
using Microsoft.Extensions.Logging;

namespace Internship.Web.Controllers
{
    public class SubjectAssessmentsController : EntityController<SubjectAssessmentDto>
    {
        public SubjectAssessmentsController(
            ILogger<SubjectAssessmentDto> logger,
            IEntityService<SubjectAssessmentDto> entityService)
            : base(logger, entityService)
        {
        }
    }
}
