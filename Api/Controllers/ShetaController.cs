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
    public class ShetaController : ControllerBase
    {
        private readonly ApiContext _context;

        public ShetaController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Sheta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shet>>> Getsheta()
        {
            return await _context.sheta.ToListAsync();
        }

        // GET: api/Sheta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shet>> GetSheta(int id)
        {
            var sheta = await _context.sheta.FindAsync(id);
            _context.sheta_tov.Where(p => p.kod_sheta == id).Include(p => p.Tovar).Load();
            if (sheta == null)
            {
                return NotFound();
            }

            return sheta;
        }

        [Route("Filter")]
        // Post: api/Sklad_rashod/Filter
        [HttpPost]
        public async Task<ActionResult<List<Shet>>> GetShetaByFilter(RashodyQueryParams? queryParams)
        {
            if (_context.sheta == null)
            {
                return NotFound();
            }

            List<Shet> _rashods = new List<Shet>();
            if (queryParams != null)
            {
                switch (queryParams.DateFilter)
                {
                    case 1:
                        {
                            _rashods = await _context.sheta.
                                Where(p => (queryParams.StartDate.HasValue ? p.date_sheta.Date >= queryParams.StartDate.Value.Date : true)
                                        && (queryParams.EndDate.HasValue ? p.date_sheta.Date <= queryParams.EndDate.Value.Date : true))
                                /*.Include(p => p.Sheta)*//*.Include(p => p.Spr_oplat_sklad)*//*.Include(p => p.Sklad_dostavki)*/.ToListAsync();
                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    case 3:
                        {
                            _rashods = await _context.sheta.
                                Where(p => (queryParams.StartDate.HasValue && p.date_oplaty.HasValue ? p.date_oplaty.Value.Date >= queryParams.StartDate.Value.Date : true)
                                        && (queryParams.EndDate.HasValue && p.date_oplaty.HasValue ? p.date_oplaty.Value.Date <= queryParams.EndDate.Value.Date : true))
                                /*.Include(p => p.Sheta)*//*.Include(p => p.Spr_oplat_sklad)*//*.Include(p => p.Sklad_dostavki)*/.ToListAsync();
                            break;
                        }
                }

                if (queryParams.SelectedOplachen != null) _rashods = _rashods.Where(p => p.oplachen == queryParams.SelectedOplachen.Value).ToList();
                if (queryParams.SelectedManager != null) _rashods = _rashods.Where(p => p.id_polz == queryParams.SelectedManager.Id).ToList();

                if (queryParams.Search != null && queryParams.Search != "")
                {
                    _rashods = _rashods.Where(p => p.nom_shet.ToString() == queryParams.Search
                                            || (p.prim != null ? p.prim.Contains(queryParams.Search) : false)).ToList();
                }
            }
            else _rashods = await _context.sheta.ToListAsync();
            _context.users.Load();
            _context.sheta_tov.Load();
            return _rashods;
        }

        // PUT: api/Sheta/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSheta(int id, Shet sheta)
        {
            if (id != sheta.kod_zap)
            {
                return BadRequest();
            }

            _context.Entry(sheta).State = EntityState.Modified;
            if (sheta.oplachen && sheta.date_oplaty == null) sheta.date_oplaty = DateTime.Now;
            else if (!sheta.oplachen) sheta.date_oplaty = null;

            if (sheta.Sheta_tov != null)
            {
                foreach(Sheta_tov tov in sheta.Sheta_tov)
                {
                    if(tov.kod_zap == 0) _context.Entry(tov).State = EntityState.Added;
                    else _context.Entry(tov).State = EntityState.Modified;
                }
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShetaExists(id))
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

        // POST: api/Sheta
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Shet>> PostSheta(Shet sheta)
        {
            sheta.date_sheta = DateTime.Now;
            sheta.id_polz = 1;
            sheta.nom_shet = _context.sheta.Where(p=>p.date_sheta.Year == sheta.date_sheta.Year).Max(p => p.nom_shet) + 1;
            _context.sheta.Add(sheta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSheta", new { id = sheta.kod_zap }, sheta);
        }

        // DELETE: api/Sheta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSheta(int id)
        {
            var sheta = await _context.sheta.FindAsync(id);
            if (sheta == null)
            {
                return NotFound();
            }

            _context.sheta.Remove(sheta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Route("Tov")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSheta_tov(int id)
        {
            if (_context.sheta_tov == null)
            {
                return NotFound();
            }
            var sheta_tov = await _context.sheta_tov.FindAsync(id);
            if (sheta_tov == null)
            {
                return NotFound();
            }

            _context.sheta_tov.Remove(sheta_tov);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShetaExists(int id)
        {
            return _context.sheta.Any(e => e.kod_zap == id);
        }
    }
}
