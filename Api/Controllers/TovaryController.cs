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
    public class TovaryController : ControllerBase
    {
        private readonly ApiContext _context;

        public TovaryController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Tovary
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetTovary()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/Tovary/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetTovary(int id)
        {
            var Products = await _context.Products.FindAsync(id);

            if (Products == null)
            {
                return NotFound();
            }

            return Products;
        }

        // PUT: api/Tovary/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTovary(int id, Product Products)
        {
            if (id != Products.ID)
            {
                return BadRequest();
            }

            if (Products.ID == 0) _context.Entry(Products).State = EntityState.Added;
            else _context.Entry(Products).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TovaryExists(id))
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

        // POST: api/Tovary
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostTovary(Product Products)
        {
            _context.Products.Add(Products);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTovary", new { id = Products.ID }, Products);
        }

        // DELETE: api/Tovary/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTovary(int id)
        {
            var Products = await _context.Products.FindAsync(id);
            if (Products == null)
            {
                return NotFound();
            }

            _context.Products.Remove(Products);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TovaryExists(int id)
        {
            return _context.Products.Any(e => e.ID == id);
        }
    }
}
