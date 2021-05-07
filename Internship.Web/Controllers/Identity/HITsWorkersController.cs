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
    public class HITsWorkersController : ControllerBase
    {
        private readonly InternshipDbContext _context;

        public HITsWorkersController(InternshipDbContext context)
        {
            _context = context;
        }

        // GET: api/HITsWorkers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HITsWorker>>> GetHITsWorkers()
        {
            return await _context.HITsWorkers.ToListAsync();
        }

        // GET: api/HITsWorkers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HITsWorker>> GetHITsWorker(Guid id)
        {
            var hITsWorker = await _context.HITsWorkers.FindAsync(id);

            if (hITsWorker == null)
            {
                return NotFound();
            }

            return hITsWorker;
        }

        // PUT: api/HITsWorkers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHITsWorker(Guid id, HITsWorker hITsWorker)
        {
            if (id != hITsWorker.Id)
            {
                return BadRequest();
            }

            _context.Entry(hITsWorker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HITsWorkerExists(id))
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

        // POST: api/HITsWorkers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HITsWorker>> PostHITsWorker(HITsWorker hITsWorker)
        {
            _context.HITsWorkers.Add(hITsWorker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHITsWorker", new { id = hITsWorker.Id }, hITsWorker);
        }

        // DELETE: api/HITsWorkers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHITsWorker(Guid id)
        {
            var hITsWorker = await _context.HITsWorkers.FindAsync(id);
            if (hITsWorker == null)
            {
                return NotFound();
            }

            _context.HITsWorkers.Remove(hITsWorker);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HITsWorkerExists(Guid id)
        {
            return _context.HITsWorkers.Any(e => e.Id == id);
        }
    }
}
