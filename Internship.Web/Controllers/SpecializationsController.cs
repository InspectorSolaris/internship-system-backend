using Internship.BL.Interfaces.Common;
using Internship.Common.Dtos;
using Internship.Web.Controllers.Common;
using Microsoft.Extensions.Logging;

namespace Internship.Web.Controllers
{
    public class SpecializationsController : EntityController<SpecializationDto>
    {
        public SpecializationsController(
            ILogger<SpecializationDto> logger,
            IEntityService<SpecializationDto> entityService)
            : base(logger, entityService)
        {
        }
    }
}
