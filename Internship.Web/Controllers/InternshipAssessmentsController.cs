using Internship.BL.Interfaces.Common;
using Internship.Common.Dtos;
using Internship.Web.Controllers.Common;
using Microsoft.Extensions.Logging;

namespace Internship.Web.Controllers
{
    public class InternshipAssessmentsController : EntityController<InternshipAssessmentDto>
    {
        public InternshipAssessmentsController(
            ILogger<InternshipAssessmentDto> logger,
            IEntityService<InternshipAssessmentDto> entityService)
            : base(logger, entityService)
        {
        }
    }
}
