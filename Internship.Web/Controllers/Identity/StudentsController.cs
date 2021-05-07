using Internship.Common.DTOs.Identity;
using Internship.DAL.Context;
using Internship.DAL.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.Web.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly InternshipDbContext _context;

        public StudentsController(InternshipDbContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudents()
        {
            return await _context.Students
                .Include(e => e.Specializations)
                .Include(e => e.Technologies)
                .Select(e => new StudentDTO()
                {
                    Id = e.Id,
                    UserName = e.UserName,
                    Email = e.Email,
                    Info = e.Info,
                    FirstName = e.FirstName,
                    MiddleName = e.MiddleName,
                    LastName = e.LastName,
                    Specializations = e.Specializations.Select(s => s.Id).ToList(),
                    Technologies = e.Technologies.Select(s => s.Id).ToList()
                })
                .ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDTO>> GetStudent(Guid id)
        {
            var student = await _context.Students
                .Include(e => e.Specializations)
                .Include(e => e.Technologies)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return new StudentDTO()
            {
                Id = student.Id,
                UserName = student.UserName,
                Email = student.Email,
                Info = student.Info,
                FirstName = student.FirstName,
                MiddleName = student.MiddleName,
                LastName = student.LastName,
                Specializations = student.Specializations.Select(s => s.Id).ToList(),
                Technologies = student.Technologies.Select(s => s.Id).ToList()
            };
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(Guid id, StudentDTO student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentDTO>> PostStudent(StudentDTO student)
        {
            _context.Students.Add(new Student()
            {
                Id = Guid.NewGuid(),
                UserName = student.UserName,
                Email = student.Email,
                Info = student.Info,
                FirstName = student.FirstName,
                MiddleName = student.MiddleName,
                LastName = student.LastName,
                Specializations = await _context.Specializations.Where(e => student.Specializations.Contains(e.Id)).ToListAsync(),
                Technologies = await _context.Technologies.Where(e => student.Technologies.Contains(e.Id)).ToListAsync()
            });
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(Guid id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
