using Internship.BL.Interfaces.Common;
using Internship.Common.Dtos.Common;
using Internship.DAL.Context;
using Internship.DAL.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Internship.BL.Services.Common
{
    public abstract class EntityService<TEntity, TEntityDto> : IEntityService<TEntity, TEntityDto>
        where TEntity : Entity
        where TEntityDto : EntityDto
    {
        protected readonly InternshipDbContext _context;

        protected EntityService(InternshipDbContext context)
        {
            _context = context;
        }

        protected abstract IQueryable<TEntity> GetQuery(bool include = false);

        protected abstract TEntityDto GetDto(TEntity entity);

        public abstract void Create(TEntityDto entityDto);

        public virtual IEnumerable<TEntityDto> Retrieve()
        {
            return GetQuery(true)
                .Select(entity => GetDto(entity));
        }

        public virtual TEntityDto Retrieve(Guid id)
        {
            var entity = GetQuery(true)
                .FirstOrDefault(entity => entity.Id == id);

            return GetDto(entity);
        }

        public abstract void Update(TEntityDto entityDto);

        public abstract void Delete(Guid id);
    }
}
