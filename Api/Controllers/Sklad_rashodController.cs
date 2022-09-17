using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models;
using Api.ViewModels;
using Api.Models.Sklad;

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

        [Route("Filter")]
        // Post: api/Sklad_rashod/Filter
        [HttpPost]
        public async Task<ActionResult<List<Sklad_rashod>>> GetSklad_rashodByFilter(RashodyQueryParams? queryParams)
        {
            if (_context.Sklad_rashod == null)
            {
                return NotFound();
            }

            List<Sklad_rashod> _rashods = new List<Sklad_rashod>();
            if (queryParams != null)
            {
                switch (queryParams.DateFilter)
                {
                    case 1:
                        {
                            _rashods = await _context.Sklad_rashod.
                                Where(p => (queryParams.StartDate.HasValue ? p.data_rash >= queryParams.StartDate.Value : true)
                                        && (queryParams.EndDate.HasValue ? p.data_rash <= queryParams.EndDate : true))
                                .Include(p => p.Sheta).Include(p => p.Spr_oplat_sklad).Include(p => p.Sklad_dostavki).ToListAsync();
                            break;
                        }
                    case 2:
                        {
                            _rashods = await _context.Sklad_rashod.
                                Where(p => (queryParams.StartDate.HasValue ? p.data_otgruzki >= queryParams.StartDate.Value : true)
                                        && (queryParams.EndDate.HasValue ? p.data_otgruzki <= queryParams.EndDate : true))
                                .Include(p => p.Sheta).Include(p => p.Spr_oplat_sklad).Include(p => p.Sklad_dostavki).ToListAsync();
                            break;
                        }
                    case 3:
                        {
                            _rashods = await _context.Sklad_rashod.
                                Where(p => (queryParams.StartDate.HasValue ? p.data_opl >= queryParams.StartDate.Value : true)
                                        && (queryParams.EndDate.HasValue ? p.data_opl <= queryParams.EndDate : true))
                                .Include(p => p.Sheta).Include(p => p.Spr_oplat_sklad).Include(p => p.Sklad_dostavki).ToListAsync();
                            break;
                        }
                }

                if (queryParams.Search != null && queryParams.Search != "")
                {
                    _rashods = _rashods.Where(p => p.nom_rash.ToString() == queryParams.Search || p.shet.GetValueOrDefault().ToString() == queryParams.Search
                                            || (p.first_phone != null ? p.first_phone.Contains(queryParams.Search) : false)
                                            || (p.name_kontact_person != null ? p.name_kontact_person.Contains(queryParams.Search) : false)
                                            || (p.name_pokup != null ? p.name_pokup.Contains(queryParams.Search) : false)
                                            || (p.otpustil != null ? p.otpustil.Contains(queryParams.Search) : false)
                                            || (p.phone_pokup.GetValueOrDefault().ToString().Contains(queryParams.Search))
                                            || (p.prim != null ? p.prim.Contains(queryParams.Search) : false)
                                            || (p.primZavSklad != null ? p.primZavSklad.Contains(queryParams.Search) : false)
                                            || (p.prim_buh != null ? p.prim_buh.Contains(queryParams.Search) : false)
                                            || (p.second_phone != null ? p.second_phone.Contains(queryParams.Search) : false)).ToList();
                }
            }
            else _rashods = await _context.Sklad_rashod.ToListAsync();
            
            return _rashods;
        }

        [Route("VM")]
        // Get: api/Sklad_rashod/VM
        [HttpGet]
        public async Task<ActionResult<RashodyViewModel>> GetSklad_rashodVM()
        {
            if (_context.Sklad_rashod == null)
            {
                return NotFound();
            }

            return await new RashodyViewModel().GetVM(_context);
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
