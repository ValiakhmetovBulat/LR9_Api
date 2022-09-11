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
    public class Sklad_rashodController : ControllerBase
    {
        private readonly ApiContext _context;

        public Sklad_rashodController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Sklad_rashod
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sklad_rashod>>> GetSklad_rashod()
        {
            if (_context.Sklad_rashod == null)
            {
                return NotFound();
            }
            var result = await _context.Sklad_rashod.Take(2).Include(p=>p.Sklad_rashod_tov).ToListAsync();
            return result;
        }

        [Route("Sklad_rashod_date")]
        // GET: api/Sklad_rashod/Sklad_rashod_date
        // GET: api/Sklad_rashod/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sklad_rashod>>> GetSklad_rashod_ByDate(DateTime? start, DateTime? end, string? search)
        {
            if (_context.Sklad_rashod == null)
            {
                return NotFound();
            }
            var result = await _context.Sklad_rashod.Where(p => (start.HasValue ? p.data_rash >= start.Value : true) && (end.HasValue ? p.data_rash <= end.Value : true))
                //.Include(p => p.Sklad_rashod_tov)
                .Include(p => p.Sheta)
                .Include(p => p.Spr_oplat_sklad)
                .Include(p => p.Sklad_dostavki)
                .ToListAsync();
            if (search != null && search != "")
            {
                result = result.Where(p => p.nom_rash.ToString() == search || p.shet.GetValueOrDefault().ToString() == search
                                        || (p.first_phone != null ? p.first_phone.Contains(search) :false) 
                                        || (p.name_kontact_person != null ? p.name_kontact_person.Contains(search)  : false)
                                        || (p.name_pokup != null ? p.name_pokup.Contains(search) : false) 
                                        || (p.otpustil != null ? p.otpustil.Contains(search) : false) 
                                        || (p.phone_pokup.GetValueOrDefault().ToString().Contains(search))
                                        || (p.prim != null ? p.prim.Contains(search) : false) 
                                        || (p.primZavSklad != null ? p.primZavSklad.Contains(search) : false) 
                                        || (p.prim_buh != null ? p.prim_buh.Contains(search) : false)
                                        || (p.second_phone != null ? p.second_phone.Contains(search) : false)).ToList();
            }
            return result;
        }



        [Route("Sklad_rashod")]
        // GET: api/Sklad_rashod/Sklad_rashod?year=2022&month=3
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sklad_rashod>>> GetSklad_rashod_ByDate(int year, int month)
        {
            if (_context.Sklad_rashod == null)
            {
                return NotFound();
            }
            var result = await _context.Sklad_rashod.Where(p => p.data_rash.Value.Year == year && p.data_rash.Value.Month == month).Include(p => p.Sklad_rashod_tov).ToListAsync();
            return result;
        }

        // GET: api/Sklad_rashod/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sklad_rashod>> GetSklad_rashod(decimal id)
        {
          if (_context.Sklad_rashod == null)
          {
              return NotFound();
          }
            var sklad_rashod = await _context.Sklad_rashod.FindAsync(id);

            if (sklad_rashod == null)
            {
                return NotFound();
            }

            return sklad_rashod;
        }

        // PUT: api/Sklad_rashod/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSklad_rashod(decimal id, Sklad_rashod sklad_rashod)
        {
            if (id != sklad_rashod.kod_zap)
            {
                return BadRequest();
            }

            _context.Entry(sklad_rashod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sklad_rashodExists(id))
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

        // POST: api/Sklad_rashod
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sklad_rashod>> PostSklad_rashod(Sklad_rashod sklad_rashod)
        {
            if (_context.Sklad_rashod == null)
            {
                return Problem("Entity set 'ApiContext.Sklad_rashod'  is null.");
            }
            sklad_rashod.data_rash = DateTime.Now; 
            sklad_rashod.data_sozdania = DateTime.Now;
            sklad_rashod.nom_rash = _context.Sklad_rashod.Where(p => p.data_sozdania.Value.Year == DateTime.Now.Year).Max(p => p.nom_rash) + 1;
            sklad_rashod.otpustil = Environment.UserName;
            _context.Sklad_rashod.Add(sklad_rashod);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Sklad_rashodExists(sklad_rashod.kod_zap.Value))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSklad_rashod", new { id = sklad_rashod.kod_zap }, sklad_rashod);
        }

        // DELETE: api/Sklad_rashod/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSklad_rashod(decimal id)
        {
            if (_context.Sklad_rashod == null)
            {
                return NotFound();
            }
            var sklad_rashod = await _context.Sklad_rashod.FindAsync(id);
            if (sklad_rashod == null)
            {
                return NotFound();
            }

            _context.Sklad_rashod.Remove(sklad_rashod);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Sklad_rashodExists(decimal id)
        {
            return (_context.Sklad_rashod?.Any(e => e.kod_zap == id)).GetValueOrDefault();
        }
    }
}
