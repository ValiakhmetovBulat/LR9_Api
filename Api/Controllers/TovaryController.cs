using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TovaryController : ControllerBase
    {
        private readonly ApiContext _context;

        public TovaryController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Tovary
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tovary>>> GetTovary()
        {
            return await _context.tovary.ToListAsync();
        }

        // GET: api/Tovary/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tovary>> GetTovary(int id)
        {
            var tovary = await _context.tovary.FindAsync(id);

            if (tovary == null)
            {
                return NotFound();
            }

            return tovary;
        }

        // PUT: api/Tovary/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTovary(int id, Tovary tovary)
        {
            if (id != tovary.kod_tovara)
            {
                return BadRequest();
            }

            if (tovary.kod_tovara == 0) _context.Entry(tovary).State = EntityState.Added;
            else _context.Entry(tovary).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TovaryExists(id))
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

        // POST: api/Tovary
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tovary>> PostTovary(Tovary tovary)
        {
            _context.tovary.Add(tovary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTovary", new { id = tovary.kod_tovara }, tovary);
        }

        // DELETE: api/Tovary/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTovary(int id)
        {
            var tovary = await _context.tovary.FindAsync(id);
            if (tovary == null)
            {
                return NotFound();
            }

            _context.tovary.Remove(tovary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TovaryExists(int id)
        {
            return _context.tovary.Any(e => e.kod_tovara == id);
        }
    }
}
