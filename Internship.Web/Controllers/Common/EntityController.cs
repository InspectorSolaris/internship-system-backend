using Internship.BL.Interfaces.Common;
using Internship.Common.Dtos.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Internship.Web.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class EntityController<TEntityDto> : ControllerBase
        where TEntityDto : EntityDto
    {
        private readonly ILogger<TEntityDto> _logger;

        private readonly IEntityService<TEntityDto> _entityService;

        protected EntityController(
            ILogger<TEntityDto> logger,
            IEntityService<TEntityDto> entityService)
        {
            _logger = logger;
            _entityService = entityService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntityDto>>> Get()
        {
            try
            {
                var entities = await _entityService.Retrieve();

                return new ActionResult<IEnumerable<TEntityDto>>(entities);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "");

                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TEntityDto>> Get([FromRoute] Guid id)
        {
            try
            {
                if (!await _entityService.Exists(id))
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                return await _entityService.Retrieve(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "");

                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPut]
        public async Task<ActionResult<TEntityDto>> Put([FromBody] TEntityDto entityDto)
        {
            try
            {
                if (!await _entityService.Exists(entityDto.Id))
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                await _entityService.Update(entityDto);

                return await _entityService.Retrieve(entityDto.Id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "");

                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPost]
        public async Task<ActionResult<TEntityDto>> Post([FromBody] TEntityDto entityDto)
        {
            try
            {
                var entityId = await _entityService.Create(entityDto);

                return await _entityService.Retrieve(entityId);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "");

                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                await _entityService.Delete(id);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "");

                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
