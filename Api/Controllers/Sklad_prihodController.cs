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
    public class Sklad_prihodController : ControllerBase
    {
        private readonly ApiContext _context;

        public Sklad_prihodController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Sklad_prihod
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sklad_prihod>>> GetSklad_prihod()
        {
            return await _context.sklad_prihod.Include(p=>p.Sklad_prihod_tov).ToListAsync();
        }

        // GET: api/Sklad_prihod/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sklad_prihod>> GetSklad_prihod(int id)
        {
            var sklad_prihod = await _context.sklad_prihod.FindAsync(id);

            if (sklad_prihod == null)
            {
                return NotFound();
            }
            _context.sklad_prihod_tov.Where(p => p.kod_prihoda == id).Include(p => p.Tovar).Load();
            return sklad_prihod;
        }

        [Route("Filter")]
        [HttpPost]
        public async Task<ActionResult<List<Sklad_prihod>>> GetSklad_rashodByFilter(RashodyQueryParams? queryParams)
        {
            if (_context.sklad_prihod == null)
            {
                return NotFound();
            }

            List<Sklad_prihod> _prihods = new List<Sklad_prihod>();
            if (queryParams != null)
            {
                _prihods = _context.sklad_prihod.
                                Where(p => (queryParams.StartDate.HasValue ? p.date_prih.Date >= queryParams.StartDate.Value.Date : true)
                                        && (queryParams.EndDate.HasValue ? p.date_prih.Date <= queryParams.EndDate.Value.Date : true)).Include(p=>p.Polz).ToList();

                if (queryParams.Search != null && queryParams.Search != "")
                {
                    _prihods = _prihods.Where(p => p.nom_prih.ToString() == queryParams.Search
                                            || (p.prim != null ? p.prim.Contains(queryParams.Search) : false)).ToList();
                }
            }
            else _prihods = await _context.sklad_prihod.Include(p=>p.Polz).ToListAsync();
            _context.sklad_prihod_tov.Include(p => p.Tovar).Load();
            return _prihods;
        }

        // PUT: api/Sklad_prihod/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSklad_prihod(int id, Sklad_prihod sklad_prihod)
        {
            if (id != sklad_prihod.kod_zap)
            {
                return BadRequest();
            }

            _context.Entry(sklad_prihod).State = EntityState.Modified;
            foreach (Sklad_prihod_tov tov in sklad_prihod.Sklad_prihod_tov)
            {
                if (tov.kod_zap == null || tov.kod_zap == 0) _context.Entry(tov).State = EntityState.Added;
                else _context.Entry(tov).State = EntityState.Modified;
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sklad_prihodExists(id))
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

        // POST: api/Sklad_prihod
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sklad_prihod>> PostSklad_prihod(Sklad_prihod sklad_prihod)
        {
            sklad_prihod.nom_prih = _context.sklad_prihod.Max(p=>p.nom_prih) + 1;
            sklad_prihod.date_prih = DateTime.Now;
            sklad_prihod.is_corrected = false;
            sklad_prihod.transport_ot_post = false;
            sklad_prihod.dop_rash = 0;
            sklad_prihod.cost_dost = 0;

            _context.sklad_prihod.Add(sklad_prihod);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSklad_prihod", new { id = sklad_prihod.kod_zap }, sklad_prihod);
        }

        // DELETE: api/Sklad_prihod/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSklad_prihod(int id)
        {
            var sklad_prihod = await _context.sklad_prihod.FindAsync(id);
            if (sklad_prihod == null)
            {
                return NotFound();
            }

            _context.sklad_prihod.Remove(sklad_prihod);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Route("Tov")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSklad_prihod_tov(int id)
        {
            if (_context.sklad_prihod == null)
            {
                return NotFound();
            }
            var Sklad_prihod_tov = await _context.sklad_prihod_tov.FindAsync(id);
            if (Sklad_prihod_tov == null)
            {
                return NotFound();
            }

            _context.sklad_prihod_tov.Remove(Sklad_prihod_tov);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Sklad_prihodExists(int id)
        {
            return _context.sklad_prihod.Any(e => e.kod_zap == id);
        }
    }
}
