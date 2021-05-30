using Internship.Common.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Internship.BL.Interfaces.Common
{
    public interface IEntityService<TEntityDto>
        where TEntityDto : EntityDto
    {
        Task<Guid> Create(TEntityDto entityDto);

        Task<IEnumerable<TEntityDto>> Retrieve();

        Task<TEntityDto> Retrieve(Guid id);

        Task Update(TEntityDto entityDto);

        Task Delete(Guid id);

        Task<bool> Exists(Guid id);
    }
}
