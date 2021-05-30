using Internship.BL.Services.Common;
using Internship.Common.Dtos;
using Internship.DAL.Context;
using Internship.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.BL.Services
{
    public class SpecializationService : EntityService<Specialization, SpecializationDto>
    {
        public SpecializationService(
            InternshipDbContext context)
            : base(context)
        {
        }

        protected override DbSet<Specialization> DbSet => _context.Specializations;

        protected override IQueryable<Specialization> Query => _context.Specializations
            .Include(entity => entity.Users)
            .Include(entity => entity.Technologies);

        protected override SpecializationDto GetDto(Specialization entity)
        {
            var entityDto = base.GetDto(entity);

            entityDto.Name = entity.Name;
            entityDto.Users = entity.Users.Select(user => user.Id);
            entityDto.Technologies = entity.Technologies.Select(entity => entity.Id);

            return entityDto;
        }

        protected async override Task Update(Specialization entity, SpecializationDto entityDto)
        {
            await base.Update(entity, entityDto);

            entity.Name = entityDto.Name;
            entity.Users = await _context.Users.Where(user => entityDto.Users.Contains(user.Id)).ToListAsync();
            entity.Technologies = await _context.Technologies.Where(entity => entityDto.Technologies.Contains(entity.Id)).ToListAsync();
        }
    }
}
