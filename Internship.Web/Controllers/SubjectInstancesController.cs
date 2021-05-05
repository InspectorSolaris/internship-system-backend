using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Internship.DAL.Context;
using Internship.DAL.Models;

namespace Internship.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectInstancesController : ControllerBase
    {
        private readonly InternshipDbContext _context;

        public SubjectInstancesController(InternshipDbContext context)
        {
            _context = context;
        }

        // GET: api/SubjectInstances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectInstance>>> GetSubjectInstances()
        {
            return await _context.SubjectInstances.ToListAsync();
        }

        // GET: api/SubjectInstances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectInstance>> GetSubjectInstance(Guid id)
        {
            var subjectInstance = await _context.SubjectInstances.FindAsync(id);

            if (subjectInstance == null)
            {
                return NotFound();
            }

            return subjectInstance;
        }

        // PUT: api/SubjectInstances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubjectInstance(Guid id, SubjectInstance subjectInstance)
        {
            if (id != subjectInstance.Id)
            {
                return BadRequest();
            }

            _context.Entry(subjectInstance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectInstanceExists(id))
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

        // POST: api/SubjectInstances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubjectInstance>> PostSubjectInstance(SubjectInstance subjectInstance)
        {
            _context.SubjectInstances.Add(subjectInstance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubjectInstance", new { id = subjectInstance.Id }, subjectInstance);
        }

        // DELETE: api/SubjectInstances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubjectInstance(Guid id)
        {
            var subjectInstance = await _context.SubjectInstances.FindAsync(id);
            if (subjectInstance == null)
            {
                return NotFound();
            }

            _context.SubjectInstances.Remove(subjectInstance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubjectInstanceExists(Guid id)
        {
            return _context.SubjectInstances.Any(e => e.Id == id);
        }
    }
}
