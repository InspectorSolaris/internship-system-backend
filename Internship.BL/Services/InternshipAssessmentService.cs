using Internship.BL.Services.Common;
using Internship.Common.Dtos;
using Internship.DAL.Context;
using Internship.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.BL.Services
{
    public class InternshipAssessmentService : EntityService<InternshipAssessment, InternshipAssessmentDto>
    {
        public InternshipAssessmentService(
            InternshipDbContext context)
            : base(context)
        {
        }

        protected override DbSet<InternshipAssessment> DbSet => _context.InternshipAssessments;

        protected override IQueryable<InternshipAssessment> Query => _context.InternshipAssessments;

        protected override InternshipAssessmentDto GetDto(InternshipAssessment entity)
        {
            var entityDto = base.GetDto(entity);

            entityDto.Value = entity.Value;
            entityDto.StudentId = entity.StudentId;
            entityDto.CompanyId = entity.CompanyId;

            return entityDto;
        }

        protected async override Task Update(InternshipAssessment entity, InternshipAssessmentDto entityDto)
        {
            await base.Update(entity, entityDto);

            entity.Value = entityDto.Value;
            entity.StudentId = entityDto.StudentId;
            entity.CompanyId = entityDto.CompanyId;
        }
    }
}
