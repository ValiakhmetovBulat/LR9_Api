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
        public async Task<ActionResult<IEnumerable<Zen_roznichnie>>> GetZen_roznichnie()
        {

            return await _context.Zen_roznichnie.Include(p=>p.Tovar).ToListAsync();
        }

        // GET: api/Zen_roznichnie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Zen_roznichnie>> GetZen_roznichnie(int id)
        {
            var zen_roznichnie = _context.Zen_roznichnie.Where(p => p.tov == id && p.zena_ot_lista > 0 && p.zena_ot_4x_pachek > 0 && p.zena_ot_pachki > 0
                                                                                && p.zena_ot_lista_nal > 0 && p.zena_ot_4x_pachek_nal > 0 && p.zena_ot_pachki_nal > 0).FirstOrDefault();
            if (_context.Tovary == null) return NotFound();
            Tovary t = _context.Tovary.Find(id);
            if(t == null) return NotFound();
            if (zen_roznichnie == null)
            {
                zen_roznichnie = _context.Zen_roznichnie.Where(p => p.Tovar.IsEquals(t) && p.zena_ot_lista > 0 && p.zena_ot_4x_pachek > 0 && p.zena_ot_pachki > 0
                                                                                && p.zena_ot_lista_nal > 0 && p.zena_ot_4x_pachek_nal > 0 && p.zena_ot_pachki_nal > 0).FirstOrDefault();
                if(zen_roznichnie == null) return NotFound();
            }

            return zen_roznichnie;
        }

        // GET: api/Zen_roznichnie/5
        [Route("Zena")]
        [HttpGet]
        public async Task<ActionResult<decimal>> GetZena(int id, int tipOplaty, int count)
        {
            decimal? zena = -1;
            var zen_roznichnie = _context.Zen_roznichnie.Where(p => p.tov == id && p.zena_ot_lista > 0 && p.zena_ot_4x_pachek > 0 && p.zena_ot_pachki > 0
                                                                                && p.zena_ot_lista_nal > 0 && p.zena_ot_4x_pachek_nal > 0 && p.zena_ot_pachki_nal > 0).FirstOrDefault();
            if (_context.Tovary == null) return NotFound();
            Tovary t = _context.Tovary.Find(id);
            if (t == null) return NotFound();
            if (zen_roznichnie == null)
            {
                zen_roznichnie = _context.Zen_roznichnie.Where(p => p.Tovar.IsEquals(t) && p.zena_ot_lista > 0 && p.zena_ot_4x_pachek > 0 && p.zena_ot_pachki > 0
                                                                                && p.zena_ot_lista_nal > 0 && p.zena_ot_4x_pachek_nal > 0 && p.zena_ot_pachki_nal > 0).FirstOrDefault();
                if (zen_roznichnie == null) return NotFound();
            }

            _context.Prays_Zagolovki.Where(p => p.kod_zap == zen_roznichnie.kod_zagolovka).Load();
            if (zen_roznichnie.Zagolovki == null) return BadRequest("У товара нет заголовка");
            if (count >= zen_roznichnie.Zagolovki.number2)
            {
                if (tipOplaty == 2) zena = zen_roznichnie.zena_ot_4x_pachek;
                else zena = zen_roznichnie.zena_ot_4x_pachek;
            }
            else if (count >= zen_roznichnie.Zagolovki.number1)
            {
                if (tipOplaty == 2) zena = zen_roznichnie.zena_ot_pachki;
                else zena = zen_roznichnie.zena_ot_pachki_nal;
            }
            else
            {
                if (tipOplaty == 2) zena = zen_roznichnie.zena_ot_lista;
                else zena = zen_roznichnie.zena_ot_lista_nal;
            }

            if (zena == null) return BadRequest("Неверная цена");

            return zena.Value;
        }

        // PUT: api/Zen_roznichnie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZen_roznichnie(int id, Zen_roznichnie zen_roznichnie)
        {
            if (id != zen_roznichnie.tov)
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
        public async Task<ActionResult<Zen_roznichnie>> PostZen_roznichnie(Zen_roznichnie zen_roznichnie)
        {
            _context.Zen_roznichnie.Add(zen_roznichnie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Zen_roznichnieExists(zen_roznichnie.tov))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetZen_roznichnie", new { id = zen_roznichnie.tov }, zen_roznichnie);
        }

        // DELETE: api/Zen_roznichnie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZen_roznichnie(int id)
        {
            var zen_roznichnie = await _context.Zen_roznichnie.FindAsync(id);
            if (zen_roznichnie == null)
            {
                return NotFound();
            }

            _context.Zen_roznichnie.Remove(zen_roznichnie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Zen_roznichnieExists(int id)
        {
            return _context.Zen_roznichnie.Any(e => e.tov == id);
        }
    }
}
