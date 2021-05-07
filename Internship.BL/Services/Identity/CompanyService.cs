using Internship.Common.Dtos.Identity;
using Internship.DAL.Context;
using Internship.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Internship.BL.Services.Identity
{
    class CompanyService : UserService<Company, CompanyDto>
    {
        public CompanyService(
            InternshipDbContext context,
            UserManager<Company> userManager,
            RoleManager<Company> roleManager)
            : base(context, userManager, roleManager)
        {
        }

        protected override IQueryable<Company> GetQuery(bool full = false)
        {
            return !full ?
                _context.Companies :
                _context.Companies
                    .Include(user => user.Positions);
        }

        protected override CompanyDto GetDto(Company user)
        {
            var userDto = base.GetDto(user);

            userDto.Positions = user.Positions.Select(entity => entity.Id);

            return userDto;
        }

        protected async override void Update(Company user, CompanyDto userDto)
        {
            base.Update(user, userDto);

            user.Positions = await _context.Positions.Where(entity => userDto.Positions.Contains(entity.Id)).ToListAsync();
        }

        public async override void Create(CompanyDto userDto)
        {
            var user = new Company()
            {
                Id = Guid.NewGuid()
            };

            Update(user, userDto);

            _context.Companies.Add(user);

            await _context.SaveChangesAsync();
        }

        public async override void Update(CompanyDto userDto)
        {
            var user = await _context.Companies
                .FirstOrDefaultAsync(user => user.Id == userDto.Id);

            Update(user, userDto);

            await _context.SaveChangesAsync();
        }

        public async override void Delete(Guid id)
        {
            var user = await _context.Companies
                .FirstOrDefaultAsync(user => user.Id == id);

            _context.Companies.Remove(user);

            await _context.SaveChangesAsync();
        }
    }
}
