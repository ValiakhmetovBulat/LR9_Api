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
    public class Sklad_tov_OSTATKIController : ControllerBase
    {
        private readonly ApiContext _context;

        public Sklad_tov_OSTATKIController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Sklad_tov_OSTATKI
        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<Sklad_tov_OSTATKI>>> GetSklad_tov_OSTATKI()
        {
            *//*_context.Products.Load();
            return await _context.sklad_tov_ostatki.ToListAsync();*//*
        }

        // GET: api/Sklad_tov_OSTATKI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<decimal>> GetSklad_tov_OSTATKI(int id)
        {
            var sklad_tov_OSTATKI = await _context.sklad_tov_ostatki.FindAsync(id);

            if (sklad_tov_OSTATKI == null || sklad_tov_OSTATKI.OSTATOK == null)
            {
                return NotFound();
            }

            return sklad_tov_OSTATKI.OSTATOK;
        }

        [HttpGet]
        [Route("categ/{id}")]
        public async Task<ActionResult<IEnumerable<Sklad_tov_OSTATKI>>> GetSklad_tov_OSTATKIByCateg(int id)
        {
            _context.Categories.Where(p => p.ID == id).Load();
            _context.Products.Where(p=>p.categoryID == id).Load();
            var sklad_tov_OSTATKI = new List<Sklad_tov_OSTATKI>();// await _context.sklad_tov_ostatki.Where(p => p.Tovar != null && p.Tovar.kod_categ == id).ToListAsync();

            if (sklad_tov_OSTATKI == null)
            {
                return NotFound();
            }

            return sklad_tov_OSTATKI;
        }*/
    }
}
