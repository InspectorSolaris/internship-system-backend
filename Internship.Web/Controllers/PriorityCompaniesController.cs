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
    public class PriorityCompaniesController : ControllerBase
    {
        private readonly InternshipDbContext _context;

        public PriorityCompaniesController(InternshipDbContext context)
        {
            _context = context;
        }

        // GET: api/PriorityCompanies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PriorityCompany>>> GetPriorityCompanies()
        {
            return await _context.PriorityCompanies.ToListAsync();
        }

        // GET: api/PriorityCompanies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PriorityCompany>> GetPriorityCompany(Guid id)
        {
            var priorityCompany = await _context.PriorityCompanies.FindAsync(id);

            if (priorityCompany == null)
            {
                return NotFound();
            }

            return priorityCompany;
        }

        // PUT: api/PriorityCompanies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPriorityCompany(Guid id, PriorityCompany priorityCompany)
        {
            if (id != priorityCompany.Id)
            {
                return BadRequest();
            }

            _context.Entry(priorityCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriorityCompanyExists(id))
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

        // POST: api/PriorityCompanies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PriorityCompany>> PostPriorityCompany(PriorityCompany priorityCompany)
        {
            _context.PriorityCompanies.Add(priorityCompany);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPriorityCompany", new { id = priorityCompany.Id }, priorityCompany);
        }

        // DELETE: api/PriorityCompanies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePriorityCompany(Guid id)
        {
            var priorityCompany = await _context.PriorityCompanies.FindAsync(id);
            if (priorityCompany == null)
            {
                return NotFound();
            }

            _context.PriorityCompanies.Remove(priorityCompany);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PriorityCompanyExists(Guid id)
        {
            return _context.PriorityCompanies.Any(e => e.Id == id);
        }
    }
}
