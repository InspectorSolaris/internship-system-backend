using Internship.BL.Services.Common;
using Internship.Common.Dtos;
using Internship.DAL.Context;
using Internship.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.BL.Services
{
    public class TechnologyService : EntityService<Technology, TechnologyDto>
    {
        public TechnologyService(
            InternshipDbContext context)
            : base(context)
        {
        }

        protected override DbSet<Technology> DbSet => _context.Technologies;

        protected override IQueryable<Technology> Query => _context.Technologies
            .Include(entity => entity.Users);

        protected override TechnologyDto GetDto(Technology entity)
        {
            var entityDto = base.GetDto(entity);

            entityDto.Name = entity.Name;
            entityDto.SpecializationId = entity.SpecializationId;
            entityDto.Users = entity.Users.Select(user => user.Id);

            return entityDto;
        }

        protected async override Task Update(Technology entity, TechnologyDto entityDto)
        {
            await base.Update(entity, entityDto);

            entity.Name = entityDto.Name;
            entity.SpecializationId = entityDto.SpecializationId;
            entity.Users = await _context.Users.Where(user => entityDto.Users.Contains(user.Id)).ToListAsync();
        }
    }
}
