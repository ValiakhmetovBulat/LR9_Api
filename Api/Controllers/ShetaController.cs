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
    public class ShetsController : ControllerBase
    {
        private readonly ApiContext _context;

        public ShetsController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Shets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shet>>> Getsheta(int? nom_shet)
        {
            _context.Users.Load();
            _context.Contractors.Load();
            _context.Shet_prods.Include(p => p.Tovar).Load();
            _context.Manufactures.Load();
            var list = await _context.Shets.OrderBy(p=>p.nom_shet).ToListAsync();
            if(nom_shet != null) list = list.Where(p=>p.nom_shet == nom_shet).ToList();
            return list.OrderBy(p=>p.nom_shet).ToList();
        }

        // GET: api/Sheta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shet>> GetSheta(int id)
        {
            var sheta = await _context.Shets.FindAsync(id);
            _context.Shet_prods.Where(p => p.shetID == id).Include(p => p.Tovar).Load();
            if (sheta == null)
            {
                return NotFound();
            }

            _context.Manufactures.Load();
            _context.Users.Where(p=>p.ID == sheta.userID).Load();
            _context.Contractors.Where(p=>p.ID == sheta.contractorID).Load();
            return sheta;
        }

        [Route("Filter")]
        // Post: api/Sklad_rashod/Filter
        [HttpPost]
        public async Task<ActionResult<List<Shet>>> GetShetaByFilter(RashodyQueryParams? queryParams)
        {
            if (_context.Shets == null)
            {
                return NotFound();
            }

            List<Shet> _sheta = new List<Shet>();
            if (queryParams != null)
            {
                switch (queryParams.DateFilter)
                {
                    case 1:
                        {
                            _sheta = await _context.Shets.
                                Where(p => (queryParams.StartDate.HasValue ? p.date_sheta.Date >= queryParams.StartDate.Value.Date : true)
                                        && (queryParams.EndDate.HasValue ? p.date_sheta.Date <= queryParams.EndDate.Value.Date : true)).ToListAsync();
                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    case 3:
                        {
                            _sheta = await _context.Shets.
                                Where(p => (queryParams.StartDate.HasValue && p.date_oplaty.HasValue ? p.date_oplaty.Value.Date >= queryParams.StartDate.Value.Date : true)
                                        && (queryParams.EndDate.HasValue && p.date_oplaty.HasValue ? p.date_oplaty.Value.Date <= queryParams.EndDate.Value.Date : true)).ToListAsync();
                            break;
                        }
                }

                if (queryParams.SelectedOplachen != null) _sheta = _sheta.Where(p => p.oplachen == queryParams.SelectedOplachen.Value).ToList();
                if (queryParams.SelectedManager != null) _sheta = _sheta.Where(p => p.userID == queryParams.SelectedManager.ID).ToList();

                if (queryParams.Search != null && queryParams.Search != "")
                {
                    _sheta = _sheta.Where(p => p.nom_shet.ToString() == queryParams.Search
                                            || (p.prim != null ? p.prim.Contains(queryParams.Search) : false)).ToList();
                }
            }
            else _sheta = await _context.Shets.OrderBy(p => p.nom_shet).ToListAsync();
            _context.Users.Load();
            _context.Contractors.Load();
            _context.Manufactures.Load();
            _context.Shet_prods.Include(p => p.Tovar).Load();
            return _sheta.OrderBy(p => p.nom_shet).ToList();
        }

        // PUT: api/Sheta/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSheta(int id, Shet sheta)
        {
            if (id != sheta.ID)
            {
                return BadRequest();
            }

            _context.Entry(sheta).State = EntityState.Modified;
            if (sheta.oplachen && sheta.date_oplaty == null) sheta.date_oplaty = DateTime.Now;
            else if (!sheta.oplachen) sheta.date_oplaty = null;

            if (sheta.Sheta_tov != null)
            {
                foreach(Shet_prods tov in sheta.Sheta_tov)
                {
                    if(tov.ID == 0) _context.Entry(tov).State = EntityState.Added;
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
            sheta.userID = 1;
            sheta.nom_shet = _context.Shets.Where(p=>p.date_sheta.Year == sheta.date_sheta.Year).Count() > 0 ? 
                _context.Shets.Where(p => p.date_sheta.Year == sheta.date_sheta.Year).Max(p => p.nom_shet) + 1 : 1;
            _context.Shets.Add(sheta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSheta", new { id = sheta.ID }, sheta);
        }

        // DELETE: api/Sheta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSheta(int id)
        {
            var sheta = await _context.Shets.FindAsync(id);
            if (sheta == null)
            {
                return NotFound();
            }

            _context.Shets.Remove(sheta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Route("Tov")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSheta_tov(int id)
        {
            if (_context.Shet_prods == null)
            {
                return NotFound();
            }
            var sheta_tov = await _context.Shet_prods.FindAsync(id);
            if (sheta_tov == null)
            {
                return NotFound();
            }

            _context.Shet_prods.Remove(sheta_tov);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShetaExists(int id)
        {
            return _context.Shets.Any(e => e.ID == id);
        }
    }
}
