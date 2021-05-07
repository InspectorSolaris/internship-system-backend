using Internship.Common.Dtos.Common;
using Internship.DAL.Models.Common;
using System;
using System.Collections.Generic;

namespace Internship.BL.Interfaces.Common
{
    public interface IEntityService<TEntity, TEntityDto>
        where TEntity : Entity
        where TEntityDto : EntityDto
    {
        void Create(TEntityDto entityDto);

        IEnumerable<TEntityDto> Retrieve();

        TEntityDto Retrieve(Guid id);

        void Update(TEntityDto entityDto);

        void Delete(Guid id);
    }
}
