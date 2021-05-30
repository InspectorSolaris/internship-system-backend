using Internship.BL.Interfaces.Common;
using Internship.Common.Dtos;
using Internship.Web.Controllers.Common;
using Microsoft.Extensions.Logging;

namespace Internship.Web.Controllers
{
    public class PositionsController : EntityController<PositionDto>
    {
        public PositionsController(
            ILogger<PositionDto> logger,
            IEntityService<PositionDto> entityService)
            : base(logger, entityService)
        {
        }
    }
}
