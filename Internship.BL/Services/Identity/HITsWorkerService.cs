using Internship.Common.Dtos.Identity;
using Internship.DAL.Context;
using Internship.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.BL.Services.Identity
{
    public class HITsWorkerService : UserService<HITsWorker, HITsWorkerDto>
    {
        public HITsWorkerService(
            InternshipDbContext context,
            UserManager<HITsWorker> userManager,
            RoleManager<Role> roleManager)
            : base(context, userManager, roleManager)
        {
        }

        protected override DbSet<HITsWorker> DbSet => _context.HITsWorkers;

        protected override IQueryable<HITsWorker> Query => _context.HITsWorkers
            .Include(user => user.Specializations)
            .Include(user => user.Technologies);

        protected override HITsWorkerDto GetDto(HITsWorker user)
        {
            var userDto = base.GetDto(user);

            userDto.FirstName = user.FirstName;
            userDto.MiddleName = user.MiddleName;
            userDto.LastName = user.LastName;

            return userDto;
        }

        protected async override Task Update(HITsWorker user, HITsWorkerDto userDto)
        {
            await base.Update(user, userDto);

            user.FirstName = userDto.FirstName;
            user.MiddleName = userDto.MiddleName;
            user.LastName = userDto.LastName;
        }
    }
}
