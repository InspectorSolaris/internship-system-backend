using Internship.BL.Interfaces.Common;
using Internship.Common.Dtos;
using Internship.Web.Controllers.Common;
using Microsoft.Extensions.Logging;

namespace Internship.Web.Controllers
{
    public class TechnologiesController : EntityController<TechnologyDto>
    {
        public TechnologiesController(
            ILogger<TechnologyDto> logger,
            IEntityService<TechnologyDto> entityService)
            : base(logger, entityService)
        {
        }
    }
}
