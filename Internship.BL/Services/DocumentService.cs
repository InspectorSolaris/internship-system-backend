using Internship.BL.Services.Common;
using Internship.Common.Dtos;
using Internship.DAL.Context;
using Internship.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.BL.Services
{
    public class DocumentService : EntityService<Document, DocumentDto>
    {
        public DocumentService(
            InternshipDbContext context)
            : base(context)
        {
        }

        protected override DbSet<Document> DbSet => _context.Documents;

        protected override IQueryable<Document> Query => _context.Documents;

        protected override DocumentDto GetDto(Document entity)
        {
            var entityDto = base.GetDto(entity);

            entityDto.Name = entity.Name;

            return entityDto;
        }

        protected async override Task Update(Document entity, DocumentDto entityDto)
        {
            await base.Update(entity, entityDto);

            entity.Name = entityDto.Name;
        }
    }
}
