using Internship.Common.Dtos.Identity;
using Internship.DAL.Models.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Internship.BL.Interfaces.Identity
{
    public interface IUserService<TUser, TUserDto>
        where TUser : User
        where TUserDto : UserDto
    {
        void Create(TUserDto userDto);

        Task<IEnumerable<TUserDto>> Retrieve();

        Task<TUserDto> Retrieve(Guid id);

        void Update(TUserDto userDto);

        void Delete(Guid id);
    }
}
