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
    public class Spr_period_filtrController : ControllerBase
    {
        private readonly ApiContext _context;

        public Spr_period_filtrController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Spr_period_filtr
        [HttpGet]
        public async Task<ActionResult<List<Spr_period_filtr>>> GetSpr_period_filtr()
        {
          if (_context.Spr_period_filtr == null)
          {
              return NotFound();
          }
            return await _context.Spr_period_filtr.ToListAsync();
        }

        // GET: api/Spr_period_filtr/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Spr_period_filtr>> GetSpr_period_filtr(decimal id)
        {
          if (_context.Spr_period_filtr == null)
          {
              return NotFound();
          }
            var spr_period_filtr = await _context.Spr_period_filtr.FindAsync(id);

            if (spr_period_filtr == null)
            {
                return NotFound();
            }

            return spr_period_filtr;
        }

        // PUT: api/Spr_period_filtr/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpr_period_filtr(decimal id, Spr_period_filtr spr_period_filtr)
        {
            if (id != spr_period_filtr.kod_zap)
            {
                return BadRequest();
            }

            _context.Entry(spr_period_filtr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Spr_period_filtrExists(id))
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

        // POST: api/Spr_period_filtr
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Spr_period_filtr>> PostSpr_period_filtr(Spr_period_filtr spr_period_filtr)
        {
          if (_context.Spr_period_filtr == null)
          {
              return Problem("Entity set 'ApiContext.Spr_period_filtr'  is null.");
          }
            _context.Spr_period_filtr.Add(spr_period_filtr);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Spr_period_filtrExists(spr_period_filtr.kod_zap))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSpr_period_filtr", new { id = spr_period_filtr.kod_zap }, spr_period_filtr);
        }

        // DELETE: api/Spr_period_filtr/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpr_period_filtr(decimal id)
        {
            if (_context.Spr_period_filtr == null)
            {
                return NotFound();
            }
            var spr_period_filtr = await _context.Spr_period_filtr.FindAsync(id);
            if (spr_period_filtr == null)
            {
                return NotFound();
            }

            _context.Spr_period_filtr.Remove(spr_period_filtr);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Spr_period_filtrExists(decimal id)
        {
            return (_context.Spr_period_filtr?.Any(e => e.kod_zap == id)).GetValueOrDefault();
        }
    }
}
