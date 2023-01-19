using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models;
using Api.Models.Sklad;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Zen_roznichnieController : ControllerBase
    {
        private readonly ApiContext _context;

        public Zen_roznichnieController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Zen_roznichnie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Price>>> GetZen_roznichnie()
        {

            return await _context.Prices.Include(p=>p.Tovar).ToListAsync();
        }

        // GET: api/Zen_roznichnie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Price>> GetZen_roznichnie(int id)
        {
            var zen_roznichnie = _context.Prices.Where(p => p.productID == id).FirstOrDefault();
            if (zen_roznichnie == null) return NotFound();

            return zen_roznichnie;
        }

        // GET: api/Zen_roznichnie/5
        [Route("Zena")]
        [HttpGet]
        public async Task<ActionResult<double>> GetZena(int id, int tipOplaty, int count)
        {
            double? zena = -1;
            var zen_roznichnie = _context.Prices.Where(p => p.productID == id).FirstOrDefault();
            if (zen_roznichnie == null) return NotFound();
            if (tipOplaty == 2) zena = zen_roznichnie.price_beznal;
            else zena = zen_roznichnie.price_nal;
            if (zena == null) return BadRequest("Неверная цена");
            return zena.Value;
        }

        // PUT: api/Zen_roznichnie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZen_roznichnie(int id, Price zen_roznichnie)
        {
            if (id != zen_roznichnie.ID)
            {
                return BadRequest();
            }

            _context.Entry(zen_roznichnie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Zen_roznichnieExists(id))
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

        // POST: api/Zen_roznichnie
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Price>> PostZen_roznichnie(Price zen_roznichnie)
        {
            _context.Prices.Add(zen_roznichnie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Zen_roznichnieExists(zen_roznichnie.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetZen_roznichnie", new { id = zen_roznichnie.ID }, zen_roznichnie);
        }

        // DELETE: api/Zen_roznichnie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZen_roznichnie(int id)
        {
            var zen_roznichnie = await _context.Prices.FindAsync(id);
            if (zen_roznichnie == null)
            {
                return NotFound();
            }

            _context.Prices.Remove(zen_roznichnie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Zen_roznichnieExists(int id)
        {
            return _context.Prices.Any(e => e.ID == id);
        }
    }
}
