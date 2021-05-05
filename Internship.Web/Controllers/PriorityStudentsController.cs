using Internship.DAL.Context;
using Internship.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriorityStudentsController : ControllerBase
    {
        private readonly InternshipDbContext _context;

        public PriorityStudentsController(InternshipDbContext context)
        {
            _context = context;
        }

        // GET: api/PriorityStudents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PriorityStudent>>> GetPriorityStudents()
        {
            return await _context.PriorityStudents.ToListAsync();
        }

        // GET: api/PriorityStudents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PriorityStudent>> GetPriorityStudent(Guid id)
        {
            var priorityStudent = await _context.PriorityStudents.FindAsync(id);

            if (priorityStudent == null)
            {
                return NotFound();
            }

            return priorityStudent;
        }

        // PUT: api/PriorityStudents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPriorityStudent(Guid id, PriorityStudent priorityStudent)
        {
            if (id != priorityStudent.Id)
            {
                return BadRequest();
            }

            _context.Entry(priorityStudent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriorityStudentExists(id))
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

        // POST: api/PriorityStudents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PriorityStudent>> PostPriorityStudent(PriorityStudent priorityStudent)
        {
            _context.PriorityStudents.Add(priorityStudent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPriorityStudent", new { id = priorityStudent.Id }, priorityStudent);
        }

        // DELETE: api/PriorityStudents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePriorityStudent(Guid id)
        {
            var priorityStudent = await _context.PriorityStudents.FindAsync(id);
            if (priorityStudent == null)
            {
                return NotFound();
            }

            _context.PriorityStudents.Remove(priorityStudent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PriorityStudentExists(Guid id)
        {
            return _context.PriorityStudents.Any(e => e.Id == id);
        }
    }
}
