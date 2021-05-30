﻿using Internship.BL.Interfaces.Common;
using Internship.Common.Dtos;
using Internship.Web.Controllers.Common;
using Microsoft.Extensions.Logging;

namespace Internship.Web.Controllers
{
    public class InterviewsController : EntityController<InterviewDto>
    {
        public InterviewsController(
            ILogger<InterviewDto> logger,
            IEntityService<InterviewDto> entityService)
            : base(logger, entityService)
        {
        }
    }
}
