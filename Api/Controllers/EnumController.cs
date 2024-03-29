﻿using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

namespace Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EnumController : ControllerBase
    {
        private readonly ApiContext _context;

        public EnumController(ApiContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        [Route("Oplaty")]
        public async Task<ActionResult<List<Type_oplaty>>> GetOplaty()
        {
            if (_context.Types_oplaty == null)
            {
                return NotFound();
            }
            //_context.Users.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _context.Types_oplaty.ToListAsync();
        }

        
        /*[HttpGet]
        [Route("Periods")]
        public async Task<ActionResult<List<Spr_period_filtr>>> GetPeriods()
        {
            if (_context.Spr_period_filtr == null)
            {
                return NotFound();
            }
            return await _context.Spr_period_filtr.ToListAsync();
        }*/

        /*[HttpGet]
        [Route("Karty")]
        public async Task<ActionResult<List<Karta>>> GetKarty()
        {
            if (_context.Karta == null)
            {
                return NotFound();
            }
            return await _context.Karta.OrderBy(p=>p.name).ToListAsync();
        }*/

        [HttpGet]
        [Route("Category")]
        public async Task<ActionResult<List<Category>>> GetCategory()
        {
            if (_context.Categories == null)
            {
                return NotFound();
            }
            return await _context.Categories.ToListAsync();
        }

        [HttpGet]
        [Route("Users")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            return await _context.Users.ToListAsync();
        }

        [HttpGet]
        [Route("YearsRashods")]
        public async Task<ActionResult<List<int>>> GetYearsRashods()
        {
            if (_context.Sklad_rashods == null)
            {
                return NotFound();
            }
            return await _context.Sklad_rashods.Where(p=>p.date_rash != null).Select(p => p.date_rash.Year).Distinct().OrderBy(p => p).ToListAsync();
        }
    }
}
