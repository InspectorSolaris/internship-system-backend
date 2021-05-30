using Internship.BL.Services.Common;
using Internship.Common.Dtos;
using Internship.DAL.Context;
using Internship.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.BL.Services
{
    public class PositionService : EntityService<Position, PositionDto>
    {
        public PositionService(
            InternshipDbContext context)
            : base(context)
        {
        }

        protected override DbSet<Position> DbSet => _context.Positions;

        protected override IQueryable<Position> Query => _context.Positions
            .Include(entity => entity.Interviews)
            .Include(entity => entity.Priorities)
            .Include(entity => entity.Assessments);

        protected override PositionDto GetDto(Position entity)
        {
            var entityDto = base.GetDto(entity);

            entityDto.StudentsAmount = entity.StudentsAmount;
            entityDto.Year = entity.Year;
            entityDto.CompanyId = entity.CompanyId;
            entityDto.Interviews = entity.Interviews.Select(entity => entity.Id);
            entityDto.Priorities = entity.Priorities.Select(entity => entity.Id);
            entityDto.Assessments = entity.Assessments.Select(entity => entity.Id);

            return entityDto;
        }

        protected async override Task Update(Position entity, PositionDto entityDto)
        {
            await base.Update(entity, entityDto);

            entity.StudentsAmount = entityDto.StudentsAmount;
            entity.Year = entityDto.Year;
            entity.CompanyId = entityDto.CompanyId;
            entity.Interviews = await _context.Interviews.Where(entity => entityDto.Interviews.Contains(entity.Id)).ToListAsync();
            entity.Priorities = await _context.PriorityCompanies.Where(entity => entityDto.Priorities.Contains(entity.Id)).ToListAsync();
            entity.Assessments = await _context.InternshipAssessments.Where(entity => entityDto.Assessments.Contains(entity.Id)).ToListAsync();
        }
    }
}
