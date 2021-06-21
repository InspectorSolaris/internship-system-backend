using Internship.BL.Services.Common;
using Internship.Common.Dtos;
using Internship.DAL.Context;
using Internship.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.BL.Services
{
    public class PriorityCompanyService : EntityService<PriorityCompany, PriorityCompanyDto>
    {
        public PriorityCompanyService(
            InternshipDbContext context)
            : base(context)
        {
        }

        protected override DbSet<PriorityCompany> DbSet => _context.PriorityCompanies;

        protected override IQueryable<PriorityCompany> Query => _context.PriorityCompanies;

        protected override PriorityCompanyDto GetDto(PriorityCompany entity)
        {
            var entityDto = base.GetDto(entity);

            entityDto.Value = entity.Value;
            entityDto.StudentId = entity.StudentId;
            entityDto.PriorityId = entity.PositionId;

            return entityDto;
        }

        protected async override Task Update(PriorityCompany entity, PriorityCompanyDto entityDto)
        {
            await base.Update(entity, entityDto);

            entity.Value = entityDto.Value;
            entity.StudentId = entityDto.StudentId;
            entity.PositionId = entityDto.PriorityId;
        }
    }
}
