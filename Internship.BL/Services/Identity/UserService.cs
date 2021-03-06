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
    public abstract class UserService<TUser, TUserDto> : IUserService<TUserDto>
        where TUser : User, new()
        where TUserDto : UserDto, new()
    {
        protected readonly InternshipDbContext _context;

        protected readonly UserManager<TUser> _userManager;

        protected readonly RoleManager<Role> _roleManager;

        protected UserService(
            InternshipDbContext context,
            UserManager<TUser> userManager,
            RoleManager<Role> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        protected abstract DbSet<TUser> DbSet { get; }

        protected abstract IQueryable<TUser> Query { get; }

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

        protected async virtual Task Update(TUser user, TUserDto userDto)
        {
            user.UserName = userDto.UserName;
            user.Email = userDto.Email;
            user.Info = userDto.Info;
            user.Specializations = await _context.Specializations.Where(entity => userDto.Specializations.Contains(entity.Id)).ToListAsync();
            user.Technologies = await _context.Technologies.Where(entity => userDto.Specializations.Contains(entity.Id)).ToListAsync();
        }

        public async virtual Task Create(TUserDto userDto)
        {
            var user = new TUser()
            {
                Id = Guid.NewGuid()
            };

            await Update(user, userDto);

            DbSet.Add(user);

            await _context.SaveChangesAsync();
        }

        public async virtual Task<IEnumerable<TUserDto>> Retrieve()
        {
            return await Query
                .Select(user => GetDto(user))
                .ToListAsync();
        }

        public async virtual Task<TUserDto> Retrieve(Guid id)
        {
            var user = await Query
                .FirstOrDefaultAsync(user => user.Id == id);

            return GetDto(user);
        }

        public async virtual Task Update(TUserDto userDto)
        {
            var user = await DbSet
                .FirstOrDefaultAsync(user => user.Id == userDto.Id);

            await Update(user, userDto);

            await _context.SaveChangesAsync();
        }

        public async virtual Task Delete(Guid id)
        {
            var user = await DbSet
                .FirstOrDefaultAsync(user => user.Id == id);

            DbSet.Remove(user);

            await _context.SaveChangesAsync();
        }

        public async virtual Task<bool> Exists(Guid id)
        {
            return await DbSet.AnyAsync(user => user.Id == id);
        }
    }
}
