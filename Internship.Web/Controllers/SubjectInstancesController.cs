using Internship.BL.Interfaces.Common;
using Internship.Common.Dtos;
using Internship.Web.Controllers.Common;
using Microsoft.Extensions.Logging;

namespace Internship.Web.Controllers
{
    public class SubjectInstancesController : EntityController<SubjectInstanceDto>
    {
        public SubjectInstancesController(
            ILogger<SubjectInstanceDto> logger,
            IEntityService<SubjectInstanceDto> entityService)
            : base(logger, entityService)
        {
        }
    }
}
