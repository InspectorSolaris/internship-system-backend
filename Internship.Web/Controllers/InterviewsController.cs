using Internship.BL.Interfaces.Common;
using Internship.Common.Dtos;
using Internship.Web.Controllers.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InterviewDto>>> GetByStudent(Guid studentId)
        {
            try
            {
                var entities = await _entityService
                    .Retrieve()
                    .ContinueWith(task => task.Result.Where(x => x.StudentId == studentId));

                return new ActionResult<IEnumerable<InterviewDto>>(entities);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "");

                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InterviewDto>>> GetByPosition(Guid positionId)
        {
            try
            {
                var entities = await _entityService
                    .Retrieve()
                    .ContinueWith(task => task.Result.Where(x => x.PositionId == positionId));

                return new ActionResult<IEnumerable<InterviewDto>>(entities);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "");

                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
