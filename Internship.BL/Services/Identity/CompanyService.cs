using Internship.Common.Dtos.Identity;
using Internship.DAL.Context;
using Internship.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.BL.Services.Identity
{
    public class CompanyService : UserService<Company, CompanyDto>
    {
        public CompanyService(
            InternshipDbContext context,
            UserManager<Company> userManager,
            RoleManager<Role> roleManager)
            : base(context, userManager, roleManager)
        {
        }

        protected override DbSet<Company> DbSet => _context.Companies;

        protected override IQueryable<Company> Query => _context.Companies
            .Include(user => user.Specializations)
            .Include(user => user.Technologies)
            .Include(user => user.Files)
            .Include(user => user.Positions);

        protected override string UserRole => "Company";

        protected override CompanyDto GetDto(Company user)
        {
            var userDto = base.GetDto(user);

            userDto.Positions = user.Positions.Select(entity => entity.Id);

            return userDto;
        }

        protected async override Task Update(Company user, CompanyDto userDto)
        {
            await base.Update(user, userDto);

            user.Positions = await _context.Positions.Where(entity => userDto.Positions.Contains(entity.Id)).ToListAsync();
        }
    }
}
