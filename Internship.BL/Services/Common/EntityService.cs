using Internship.BL.Interfaces.Common;
using Internship.Common.Dtos.Common;
using Internship.DAL.Context;
using Internship.DAL.Models.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.BL.Services.Common
{
    public abstract class EntityService<TEntity, TEntityDto> : IEntityService<TEntityDto>
        where TEntity : Entity, new()
        where TEntityDto : EntityDto, new()
    {
        protected readonly InternshipDbContext _context;

        protected EntityService(InternshipDbContext context)
        {
            _context = context;
        }

        protected abstract DbSet<TEntity> DbSet { get; }

        protected abstract IQueryable<TEntity> Query { get; }

        protected virtual TEntityDto GetDto(TEntity entity)
        {
            return entity == null ?
                null :
                new TEntityDto()
                {
                    Id = entity.Id
                };
        }

        protected async virtual Task Update(TEntity entity, TEntityDto entityDto)
        {
        }

        public async virtual Task<Guid> Create(TEntityDto entityDto)
        {
            var entity = new TEntity()
            {
                Id = Guid.NewGuid()
            };

            await Update(entity, entityDto);

            DbSet.Add(entity);

            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async virtual Task<IEnumerable<TEntityDto>> Retrieve()
        {
            var users = await Query.ToListAsync();

            return users
                .Select(user => GetDto(user))
                .ToList();
        }

        public async virtual Task<TEntityDto> Retrieve(Guid id)
        {
            var user = await Query
                .FirstOrDefaultAsync(user => user.Id == id);

            return GetDto(user);
        }

        public async virtual Task Update(TEntityDto entityDto)
        {
            var entity = await DbSet
                .FirstOrDefaultAsync(user => user.Id == entityDto.Id);

            await Update(entity, entityDto);

            await _context.SaveChangesAsync();
        }

        public async virtual Task Delete(Guid id)
        {
            var entity = await DbSet
                .FirstOrDefaultAsync(user => user.Id == id);

            DbSet.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async virtual Task<bool> Exists(Guid id)
        {
            return await DbSet.AnyAsync(user => user.Id == id);
        }
    }
}
