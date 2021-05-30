using Internship.BL.Interfaces.Common;
using Internship.Common.Dtos;
using Internship.Web.Controllers.Common;
using Microsoft.Extensions.Logging;

namespace Internship.Web.Controllers
{
    public class PriorityCompaniesController : EntityController<PriorityCompanyDto>
    {
        public PriorityCompaniesController(
            ILogger<PriorityCompanyDto> logger,
            IEntityService<PriorityCompanyDto> entityService)
            : base(logger, entityService)
        {
        }
    }
}
