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
    public class Spr_oplat_skladController : ControllerBase
    {
        private readonly ApiContext _context;

        public Spr_oplat_skladController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Spr_oplat_sklad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Spr_oplat_sklad>>> GetSpr_oplat_sklad()
        {
          if (_context.Spr_oplat_sklad == null)
          {
              return NotFound();
          }
            return await _context.Spr_oplat_sklad.ToListAsync();
        }

        // GET: api/Spr_oplat_sklad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Spr_oplat_sklad>> GetSpr_oplat_sklad(decimal id)
        {
          if (_context.Spr_oplat_sklad == null)
          {
              return NotFound();
          }
            var spr_oplat_sklad = await _context.Spr_oplat_sklad.FindAsync(id);

            if (spr_oplat_sklad == null)
            {
                return NotFound();
            }

            return spr_oplat_sklad;
        }

        // PUT: api/Spr_oplat_sklad/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpr_oplat_sklad(decimal id, Spr_oplat_sklad spr_oplat_sklad)
        {
            if (id != spr_oplat_sklad.kod_zap)
            {
                return BadRequest();
            }

            _context.Entry(spr_oplat_sklad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Spr_oplat_skladExists(id))
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

        // POST: api/Spr_oplat_sklad
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Spr_oplat_sklad>> PostSpr_oplat_sklad(Spr_oplat_sklad spr_oplat_sklad)
        {
          if (_context.Spr_oplat_sklad == null)
          {
              return Problem("Entity set 'ApiContext.Spr_oplat_sklad'  is null.");
          }
            _context.Spr_oplat_sklad.Add(spr_oplat_sklad);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Spr_oplat_skladExists(spr_oplat_sklad.kod_zap))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSpr_oplat_sklad", new { id = spr_oplat_sklad.kod_zap }, spr_oplat_sklad);
        }

        // DELETE: api/Spr_oplat_sklad/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpr_oplat_sklad(decimal id)
        {
            if (_context.Spr_oplat_sklad == null)
            {
                return NotFound();
            }
            var spr_oplat_sklad = await _context.Spr_oplat_sklad.FindAsync(id);
            if (spr_oplat_sklad == null)
            {
                return NotFound();
            }

            _context.Spr_oplat_sklad.Remove(spr_oplat_sklad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Spr_oplat_skladExists(decimal id)
        {
            return (_context.Spr_oplat_sklad?.Any(e => e.kod_zap == id)).GetValueOrDefault();
        }
    }
}
