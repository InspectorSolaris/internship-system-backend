using Internship.BL.Services.Common;
using Internship.Common.Dtos;
using Internship.DAL.Context;
using Internship.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.BL.Services
{
    public class SubjectInstanceService : EntityService<SubjectInstance, SubjectInstanceDto>
    {
        public SubjectInstanceService(
            InternshipDbContext context)
            : base(context)
        {
        }

        protected override DbSet<SubjectInstance> DbSet => _context.SubjectInstances;

        protected override IQueryable<SubjectInstance> Query => _context.SubjectInstances
            .Include(entity => entity.Students);

        protected override SubjectInstanceDto GetDto(SubjectInstance entity)
        {
            var entityDto = base.GetDto(entity);

            entityDto.Year = entity.Year;
            entityDto.SubjectId = entity.SubjectId;
            entityDto.Students = entity.Students.Select(user => user.Id);

            return entityDto;
        }

        protected async override Task Update(SubjectInstance entity, SubjectInstanceDto entityDto)
        {
            await base.Update(entity, entityDto);

            entity.Year = entityDto.Year;
            entity.SubjectId = entityDto.SubjectId;
            entity.Students = await _context.Students.Where(user => entityDto.Students.Contains(user.Id)).ToListAsync();
        }
    }
}
