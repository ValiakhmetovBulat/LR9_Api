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
    public class Sklad_prihodsController : ControllerBase
    {
        private readonly ApiContext _context;

        public Sklad_prihodsController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Sklad_prihod
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sklad_prihod>>> GetSklad_prihod()
        {
            return await _context.Sklad_prihods.Include(p=>p.Sklad_prihod_tov).ToListAsync();
        }

        // GET: api/Sklad_prihod/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sklad_prihod>> GetSklad_prihod(int id)
        {
            var Sklad_prihods = await _context.Sklad_prihods.FindAsync(id);

            if (Sklad_prihods == null)
            {
                return NotFound();
            }
            _context.Sklad_prihod_prods.Where(p => p.prihodID == id).Include(p => p.Tovar).Load();
            return Sklad_prihods;
        }

        [Route("Filter")]
        [HttpPost]
        public async Task<ActionResult<List<Sklad_prihod>>> GetSklad_rashodByFilter(RashodyQueryParams? queryParams)
        {
            if (_context.Sklad_prihods == null)
            {
                return NotFound();
            }

            List<Sklad_prihod> _prihods = new List<Sklad_prihod>();
            if (queryParams != null)
            {
                _prihods = _context.Sklad_prihods.
                                Where(p => (queryParams.StartDate.HasValue ? p.date_prih.Date >= queryParams.StartDate.Value.Date : true)
                                        && (queryParams.EndDate.HasValue ? p.date_prih.Date <= queryParams.EndDate.Value.Date : true)).Include(p=>p.Polz).ToList();

                if (queryParams.Search != null && queryParams.Search != "")
                {
                    _prihods = _prihods.Where(p => p.nom_prih.ToString() == queryParams.Search
                                            || (p.prim != null ? p.prim.Contains(queryParams.Search) : false)).ToList();
                }
            }
            else _prihods = await _context.Sklad_prihods.Include(p=>p.Polz).ToListAsync();
            _context.Sklad_prihod_prods.Include(p => p.Tovar).Load();
            return _prihods;
        }

        // PUT: api/Sklad_prihod/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSklad_prihod(int id, Sklad_prihod Sklad_prihods)
        {
            if (id != Sklad_prihods.ID)
            {
                return BadRequest();
            }

            _context.Entry(Sklad_prihods).State = EntityState.Modified;
            foreach (Sklad_prihod_prods tov in Sklad_prihods.Sklad_prihod_tov)
            {
                if (tov.ID == null || tov.ID == 0) _context.Entry(tov).State = EntityState.Added;
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
        public async Task<ActionResult<Sklad_prihod>> PostSklad_prihod(Sklad_prihod Sklad_prihods)
        {
            Sklad_prihods.nom_prih = _context.Sklad_prihods.Count() > 0 ? _context.Sklad_prihods.Max(p=>p.nom_prih) + 1 : 1;
            Sklad_prihods.date_prih = DateTime.Now;
            Sklad_prihods.is_korr = false;
            Sklad_prihods.transport_ot_post = false;
            Sklad_prihods.dop_rash = 0;
            Sklad_prihods.deliv_cost = 0;

            Sklad_prihods.userID = Convert.ToInt16(HttpContext.User.FindFirst("ID").Value);

            _context.Sklad_prihods.Add(Sklad_prihods);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSklad_prihod", new { id = Sklad_prihods.ID }, Sklad_prihods);
        }

        // DELETE: api/Sklad_prihod/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSklad_prihod(int id)
        {
            var Sklad_prihods = await _context.Sklad_prihods.FindAsync(id);
            if (Sklad_prihods == null)
            {
                return NotFound();
            }

            _context.Sklad_prihods.Remove(Sklad_prihods);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Route("Tov")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSklad_prihod_tov(int id)
        {
            if (_context.Sklad_prihods == null)
            {
                return NotFound();
            }
            var Sklad_prihod_tov = await _context.Sklad_prihod_prods.FindAsync(id);
            if (Sklad_prihod_tov == null)
            {
                return NotFound();
            }

            _context.Sklad_prihod_prods.Remove(Sklad_prihod_tov);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Sklad_prihodExists(int id)
        {
            return _context.Sklad_prihods.Any(e => e.ID == id);
        }
    }
}
