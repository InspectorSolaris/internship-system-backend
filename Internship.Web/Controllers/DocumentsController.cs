using Internship.BL.Interfaces.Common;
using Internship.Common.Dtos;
using Internship.Web.Controllers.Common;
using Microsoft.Extensions.Logging;

namespace Internship.Web.Controllers
{
    public class DocumentsController : EntityController<DocumentDto>
    {
        public DocumentsController(
            ILogger<DocumentDto> logger,
            IEntityService<DocumentDto> entityService)
            : base(logger, entityService)
        {
        }
    }
}
