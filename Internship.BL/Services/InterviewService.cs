using Internship.BL.Services.Common;
using Internship.Common.Dtos;
using Internship.DAL.Context;
using Internship.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.BL.Services
{
    public class InterviewService : EntityService<Interview, InterviewDto>
    {
        public InterviewService(
            InternshipDbContext context)
            : base(context)
        {
        }

        protected override DbSet<Interview> DbSet => _context.Interviews;

        protected override IQueryable<Interview> Query => _context.Interviews;

        protected override InterviewDto GetDto(Interview entity)
        {
            var entityDto = base.GetDto(entity);

            entityDto.Date = entity.Date;
            entityDto.StudentId = entity.StudentId;
            entityDto.PositionId = entity.PositionId;

            return entityDto;
        }

        protected async override Task Update(Interview entity, InterviewDto entityDto)
        {
            await base.Update(entity, entityDto);

            entity.Date = entityDto.Date;
            entity.StudentId = entityDto.StudentId;
            entity.PositionId = entityDto.PositionId;
        }
    }
}
