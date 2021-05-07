using Internship.BL.Interfaces.Identity;
using Internship.Common.Dtos.Identity;
using Internship.DAL.Context;
using Internship.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.BL.Services.Identity
{
    public abstract class UserService<TUser, TUserDto> : IUserService<TUser, TUserDto>
        where TUser : User
        where TUserDto : UserDto, new()
    {
        protected readonly InternshipDbContext _context;

        protected readonly UserManager<TUser> _userManager;

        protected readonly RoleManager<TUser> _roleManager;

        protected UserService(
            InternshipDbContext context,
            UserManager<TUser> userManager,
            RoleManager<TUser> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        protected abstract IQueryable<TUser> GetQuery(bool full = false);

        protected virtual TUserDto GetDto(TUser user)
        {
            return new TUserDto()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Info = user.Info,
                Specializations = user.Specializations.Select(entity => entity.Id),
                Technologies = user.Technologies.Select(entity => entity.Id)
            };
        }

        protected async virtual void Update(TUser user, TUserDto userDto)
        {
            user.UserName = userDto.UserName;
            user.Email = userDto.Email;
            user.Info = userDto.Info;
            user.Specializations = await _context.Specializations.Where(entity => userDto.Specializations.Contains(entity.Id)).ToListAsync();
            user.Technologies = await _context.Technologies.Where(entity => userDto.Specializations.Contains(entity.Id)).ToListAsync();
        }

        public abstract void Create(TUserDto userDto);

        public async virtual Task<IEnumerable<TUserDto>> Retrieve()
        {
            return await GetQuery(true)
                .Select(user => GetDto(user))
                .ToListAsync();
        }

        public async virtual Task<TUserDto> Retrieve(Guid id)
        {
            var user = await GetQuery(true)
                .FirstOrDefaultAsync(user => user.Id == id);

            return GetDto(user);
        }

        public abstract void Update(TUserDto userDto);

        public abstract void Delete(Guid id);
    }
}
