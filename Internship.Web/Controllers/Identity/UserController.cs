using Internship.BL.Interfaces.Identity;
using Internship.Common.Dtos.Identity;
using Internship.DAL.Models.Identity;
using Internship.Web.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace Internship.Web.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class UserController<TUser, TUserDto> : ControllerBase
        where TUser : User
        where TUserDto : UserDto
    {
        private readonly ILogger<TUserDto> _logger;

        private readonly IUserService<TUserDto> _userService;

        private readonly UserManager<TUser> _userManager;

        protected UserController(
            ILogger<TUserDto> logger,
            IUserService<TUserDto> userService,
            UserManager<TUser> userManager)
        {
            _logger = logger;
            _userService = userService;
            _userManager = userManager;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(string name, string password)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(name);

                if (user == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                var valid = await _userManager.CheckPasswordAsync(user, password);

                if (!valid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                var utcNow = DateTime.UtcNow;
                var claims = await _userManager.GetClaimsAsync(user);
                var jwt = new JwtSecurityToken(
                        issuer: AuthenticationConfiguration.Issuer,
                        audience: AuthenticationConfiguration.Audience,
                        notBefore: utcNow,
                        claims: claims,
                        expires: utcNow.Add(TimeSpan.FromMinutes(AuthenticationConfiguration.Lifetime)),
                        signingCredentials: new SigningCredentials(AuthenticationConfiguration.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

                return new JsonResult(new
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(jwt),
                    Name = user.UserName,
                    Roles = await _userManager.GetRolesAsync(user)
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "");

                return StatusCode(StatusCodes.Status400BadRequest);
            }
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
        public async Task<ActionResult<TUserDto>> Get([FromRoute] Guid id)
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

        [HttpPut]
        public async Task<ActionResult<TUserDto>> Put([FromBody] TUserDto userDto)
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
        public async Task<ActionResult<TUserDto>> Post([FromBody] TUserDto userDto)
        {
            try
            {
                var userId = await _userService.Create(userDto);

                return await _userService.Retrieve(userId);
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
