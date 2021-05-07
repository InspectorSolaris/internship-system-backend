using Internship.BL.Interfaces.Identity;
using Internship.Common.Dtos.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Internship.Web.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class UserController<TUserDto> : ControllerBase
        where TUserDto : UserDto
    {
        private readonly ILogger<TUserDto> _logger;

        private readonly IUserService<TUserDto> _userService;

        protected UserController(
            ILogger<TUserDto> logger,
            IUserService<TUserDto> userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TUserDto>>> Get()
        {
            try
            {
                var users = await _userService.Retrieve();

                return new ActionResult<IEnumerable<TUserDto>>(users);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "");

                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TUserDto>> Get(Guid id)
        {
            try
            {
                if (!await _userService.Exists(id))
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                return await _userService.Retrieve(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "");

                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TUserDto>> Put(TUserDto userDto)
        {
            try
            {
                if (!await _userService.Exists(userDto.Id))
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                await _userService.Update(userDto);

                return await _userService.Retrieve(userDto.Id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "");

                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPost]
        public async Task<ActionResult<TUserDto>> Post(TUserDto userDto)
        {
            try
            {
                await _userService.Create(userDto);

                return await _userService.Retrieve(userDto.Id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "");

                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _userService.Delete(id);

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
