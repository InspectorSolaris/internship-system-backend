using Internship.Common.Dtos.Identity;
using Internship.DAL.Context;
using Internship.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Internship.BL.Services.Identity
{
    public class HITsWorkerService : UserService<HITsWorker, HITsWorkerDto>
    {
        public HITsWorkerService(
            InternshipDbContext context,
            UserManager<HITsWorker> userManager,
            RoleManager<HITsWorker> roleManager)
            : base(context, userManager, roleManager)
        {
        }

        protected override IQueryable<HITsWorker> GetQuery(bool full = false)
        {
            return !full ?
                _context.HITsWorkers :
                _context.HITsWorkers;
        }

        protected override HITsWorkerDto GetDto(HITsWorker user)
        {
            var userDto = base.GetDto(user);

            userDto.FirstName = user.FirstName;
            userDto.MiddleName = user.MiddleName;
            userDto.LastName = user.LastName;

            return userDto;
        }

        protected override void Update(HITsWorker user, HITsWorkerDto userDto)
        {
            base.Update(user, userDto);

            user.FirstName = userDto.FirstName;
            user.MiddleName = userDto.MiddleName;
            user.LastName = userDto.LastName;
        }

        public async override void Create(HITsWorkerDto userDto)
        {
            var user = new HITsWorker()
            {
                Id = Guid.NewGuid()
            };

            Update(user, userDto);

            _context.HITsWorkers.Add(user);

            await _context.SaveChangesAsync();
        }

        public async override void Update(HITsWorkerDto userDto)
        {
            var user = await _context.HITsWorkers
                .FirstOrDefaultAsync(user => user.Id == userDto.Id);

            Update(user, userDto);

            await _context.SaveChangesAsync();
        }

        public async override void Delete(Guid id)
        {
            var user = await _context.HITsWorkers
                .FirstOrDefaultAsync(user => user.Id == id);

            _context.HITsWorkers.Remove(user);

            await _context.SaveChangesAsync();
        }
    }
}
