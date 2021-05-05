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
    public class InternshipAssessmentsController : ControllerBase
    {
        private readonly InternshipDbContext _context;

        public InternshipAssessmentsController(InternshipDbContext context)
        {
            _context = context;
        }

        // GET: api/InternshipAssessments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InternshipAssessment>>> GetInternshipAssessments()
        {
            return await _context.InternshipAssessments.ToListAsync();
        }

        // GET: api/InternshipAssessments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InternshipAssessment>> GetInternshipAssessment(Guid id)
        {
            var internshipAssessment = await _context.InternshipAssessments.FindAsync(id);

            if (internshipAssessment == null)
            {
                return NotFound();
            }

            return internshipAssessment;
        }

        // PUT: api/InternshipAssessments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInternshipAssessment(Guid id, InternshipAssessment internshipAssessment)
        {
            if (id != internshipAssessment.Id)
            {
                return BadRequest();
            }

            _context.Entry(internshipAssessment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InternshipAssessmentExists(id))
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

        // POST: api/InternshipAssessments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InternshipAssessment>> PostInternshipAssessment(InternshipAssessment internshipAssessment)
        {
            _context.InternshipAssessments.Add(internshipAssessment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInternshipAssessment", new { id = internshipAssessment.Id }, internshipAssessment);
        }

        // DELETE: api/InternshipAssessments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInternshipAssessment(Guid id)
        {
            var internshipAssessment = await _context.InternshipAssessments.FindAsync(id);
            if (internshipAssessment == null)
            {
                return NotFound();
            }

            _context.InternshipAssessments.Remove(internshipAssessment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InternshipAssessmentExists(Guid id)
        {
            return _context.InternshipAssessments.Any(e => e.Id == id);
        }
    }
}
