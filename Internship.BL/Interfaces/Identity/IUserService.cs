using Internship.Common.Dtos.Identity;
using Internship.DAL.Models.Identity;
using System;
using System.Collections.Generic;

namespace Internship.BL.Interfaces.Identity
{
    public interface IUserService<TUser, TUserDto>
        where TUser : User
        where TUserDto : UserDto
    {
        void Create(TUserDto entityDto);

        IEnumerable<TUserDto> Retrieve();

        TUserDto Retrieve(Guid id);

        void Update(TUserDto entityDto);

        void Delete(Guid id);
    }
}
