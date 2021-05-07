using Internship.Common.Dtos.Identity;
using Internship.DAL.Context;
using Internship.DAL.Models.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Internship.BL.Services.Identity
{
    public class StudentService : UserService<Student, StudentDto>
    {
        public StudentService(InternshipDbContext context) : base(context)
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
                    .Include(user => user.Assessments);
        }

        protected override StudentDto GetDto(Student user)
        {
            return new StudentDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Interviews = user.Interviews.Select(user => user.Id),
                Priorities = user.Priorities.Select(user => user.Id),
                SubjectInstances = user.SubjectInstances.Select(user => user.Id),
                Assessments = user.Assessments.Select(user => user.Id)
            };
        }

        public override void Create(StudentDto userDto)
        {
            throw new NotImplementedException();
        }

        public override void Update(StudentDto userDto)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Guid id)
        {
            var user = _context.Students
                .FirstOrDefault(user => user.Id == id);

            _context.Students.Remove(user);
        }
    }
}
