using Internship.BL.Services.Common;
using Internship.Common.Dtos;
using Internship.DAL.Context;
using Internship.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.BL.Services
{
    public class PriorityStudentService : EntityService<PriorityStudent, PriorityStudentDto>
    {
        public PriorityStudentService(
            InternshipDbContext context)
            : base(context)
        {
        }

        protected override DbSet<PriorityStudent> DbSet => _context.PriorityStudents;

        protected override IQueryable<PriorityStudent> Query => _context.PriorityStudents;

        protected override PriorityStudentDto GetDto(PriorityStudent entity)
        {
            var entityDto = base.GetDto(entity);

            entityDto.Value = entity.Value;
            entityDto.StudentId = entity.StudentId;
            entityDto.PriorityId = entity.PositionId;

            return entityDto;
        }

        protected async override Task Update(PriorityStudent entity, PriorityStudentDto entityDto)
        {
            await base.Update(entity, entityDto);

            entity.Value = entityDto.Value;
            entity.StudentId = entityDto.StudentId;
            entity.PositionId = entityDto.PriorityId;
        }
    }
}
