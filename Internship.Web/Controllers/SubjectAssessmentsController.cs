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
    public class SubjectAssessmentsController : ControllerBase
    {
        private readonly InternshipDbContext _context;

        public SubjectAssessmentsController(InternshipDbContext context)
        {
            _context = context;
        }

        // GET: api/SubjectAssessments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectAssessment>>> GetSubjectAssessments()
        {
            return await _context.SubjectAssessments.ToListAsync();
        }

        // GET: api/SubjectAssessments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectAssessment>> GetSubjectAssessment(Guid id)
        {
            var subjectAssessment = await _context.SubjectAssessments.FindAsync(id);

            if (subjectAssessment == null)
            {
                return NotFound();
            }

            return subjectAssessment;
        }

        // PUT: api/SubjectAssessments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubjectAssessment(Guid id, SubjectAssessment subjectAssessment)
        {
            if (id != subjectAssessment.Id)
            {
                return BadRequest();
            }

            _context.Entry(subjectAssessment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectAssessmentExists(id))
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

        // POST: api/SubjectAssessments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubjectAssessment>> PostSubjectAssessment(SubjectAssessment subjectAssessment)
        {
            _context.SubjectAssessments.Add(subjectAssessment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubjectAssessment", new { id = subjectAssessment.Id }, subjectAssessment);
        }

        // DELETE: api/SubjectAssessments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubjectAssessment(Guid id)
        {
            var subjectAssessment = await _context.SubjectAssessments.FindAsync(id);
            if (subjectAssessment == null)
            {
                return NotFound();
            }

            _context.SubjectAssessments.Remove(subjectAssessment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubjectAssessmentExists(Guid id)
        {
            return _context.SubjectAssessments.Any(e => e.Id == id);
        }
    }
}
