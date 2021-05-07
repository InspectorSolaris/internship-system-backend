using Internship.Common.Dtos.Identity;
using Internship.DAL.Context;
using Internship.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Internship.BL.Services.Identity
{
    public class StudentService : UserService<Student, StudentDto>
    {
        public StudentService(
            InternshipDbContext context,
            UserManager<Student> userManager,
            RoleManager<Student> roleManager)
            : base(context, userManager, roleManager)
        {
        }

        protected override IQueryable<Student> GetQuery(bool full = false)
        {
            return !full ?
                _context.Students :
                _context.Students
                    .Include(user => user.Interviews)
                    .Include(user => user.Priorities)
                    .Include(user => user.SubjectInstances)
                    .Include(user => user.SubjectAssessments)
                    .Include(user => user.InternshipAssessments);
        }

        protected override StudentDto GetDto(Student user)
        {
            var userDto = base.GetDto(user);

            userDto.FirstName = user.FirstName;
            userDto.MiddleName = user.MiddleName;
            userDto.LastName = user.LastName;
            userDto.Interviews = user.Interviews.Select(entity => entity.Id);
            userDto.Priorities = user.Priorities.Select(entity => entity.Id);
            userDto.SubjectInstances = user.SubjectInstances.Select(entity => entity.Id);
            userDto.SubjectAssessments = user.SubjectAssessments.Select(entity => entity.Id);
            userDto.InternshipAssessments = user.InternshipAssessments.Select(entity => entity.Id);

            return userDto;
        }

        protected async override void Update(Student user, StudentDto userDto)
        {
            base.Update(user, userDto);

            user.FirstName = userDto.FirstName;
            user.MiddleName = userDto.MiddleName;
            user.LastName = userDto.LastName;
            user.Interviews = await _context.Interviews.Where(entity => userDto.Interviews.Contains(entity.Id)).ToListAsync();
            user.Priorities = await _context.PriorityStudents.Where(entity => userDto.Priorities.Contains(entity.Id)).ToListAsync();
            user.SubjectInstances = await _context.SubjectInstances.Where(entity => userDto.SubjectInstances.Contains(entity.Id)).ToListAsync();
            user.SubjectAssessments = await _context.SubjectAssessments.Where(entity => userDto.SubjectInstances.Contains(entity.Id)).ToListAsync();
            user.InternshipAssessments = await _context.InternshipAssessments.Where(entity => userDto.InternshipAssessments.Contains(entity.Id)).ToListAsync();
        }

        public async override void Create(StudentDto userDto)
        {
            var user = new Student()
            {
                Id = Guid.NewGuid()
            };

            Update(user, userDto);

            _context.Students.Add(user);

            await _context.SaveChangesAsync();
        }

        public async override void Update(StudentDto userDto)
        {
            var user = await _context.Students
                .FirstOrDefaultAsync(user => user.Id == userDto.Id);

            Update(user, userDto);

            await _context.SaveChangesAsync();
        }

        public async override void Delete(Guid id)
        {
            var user = await _context.Students
                .FirstOrDefaultAsync(user => user.Id == id);

            _context.Students.Remove(user);

            await _context.SaveChangesAsync();
        }
    }
}
