using Internship.BL.Services.Common;
using Internship.Common.Dtos;
using Internship.DAL.Context;
using Internship.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.BL.Services
{
    public class SubjectService : EntityService<Subject, SubjectDto>
    {
        public SubjectService(
            InternshipDbContext context)
            : base(context)
        {
        }

        protected override DbSet<Subject> DbSet => _context.Subjects;

        protected override IQueryable<Subject> Query => _context.Subjects;

        protected override SubjectDto GetDto(Subject entity)
        {
            var entityDto = base.GetDto(entity);

            entityDto.Name = entity.Name;

            return entityDto;
        }

        protected async override Task Update(Subject entity, SubjectDto entityDto)
        {
            await base.Update(entity, entityDto);

            entity.Name = entityDto.Name;
        }
    }
}
