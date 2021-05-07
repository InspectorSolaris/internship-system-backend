using Internship.BL.Interfaces.Identity;
using Internship.Common.Dtos.Identity;
using Internship.DAL.Context;
using Internship.DAL.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Internship.BL.Services.Identity
{
    public abstract class UserService<TUser, TUserDto> : IUserService<TUser, TUserDto>
        where TUser : User
        where TUserDto : UserDto
    {
        protected readonly InternshipDbContext _context;

        protected UserService(InternshipDbContext context)
        {
            _context = context;
        }

        protected abstract IQueryable<TUser> GetQuery(bool full = false);

        protected abstract TUserDto GetDto(TUser user);

        public abstract void Create(TUserDto userDto);

        public virtual IEnumerable<TUserDto> Retrieve()
        {
            return GetQuery(true)
                .Select(user => GetDto(user));
        }

        public virtual TUserDto Retrieve(Guid id)
        {
            var user = GetQuery(true)
                .FirstOrDefault(user => user.Id == id);

            return GetDto(user);
        }

        public abstract void Update(TUserDto userDto);

        public abstract void Delete(Guid id);
    }
}
