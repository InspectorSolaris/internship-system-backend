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
        Task Create(TUserDto userDto);

        Task<IEnumerable<TUserDto>> Retrieve();

        Task<TUserDto> Retrieve(Guid id);

        Task Update(TUserDto userDto);

        Task Delete(Guid id);
    }
}
