using Internship.BL.Services.Common;
using Internship.Common.Dtos;
using Internship.DAL.Context;
using Internship.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.BL.Services
{
    public class SubjectAssessmentService : EntityService<SubjectAssessment, SubjectAssessmentDto>
    {
        public SubjectAssessmentService(
            InternshipDbContext context)
            : base(context)
        {
        }

        protected override DbSet<SubjectAssessment> DbSet => _context.SubjectAssessments;

        protected override IQueryable<SubjectAssessment> Query => _context.SubjectAssessments;

        protected override SubjectAssessmentDto GetDto(SubjectAssessment entity)
        {
            var entityDto = base.GetDto(entity);

            entityDto.SubjectId = entity.SubjectId;
            entityDto.StudentId = entity.StudentId;

            return entityDto;
        }

        protected async override Task Update(SubjectAssessment entity, SubjectAssessmentDto entityDto)
        {
            await base.Update(entity, entityDto);

            entity.SubjectId = entityDto.SubjectId;
            entity.StudentId = entityDto.StudentId;
        }
    }
}
