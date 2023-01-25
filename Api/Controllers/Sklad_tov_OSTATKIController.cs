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

        //GET: api/Sklad_tov_OSTATKI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product_stock>>> GetSklad_tov_OSTATKI()
        {
            List<Product_stock> product_Stocks = _context.Product_Stock.ToList();
            _context.Products.Load();
            _context.Contractors.Load();
            _context.Manufactures.Load();
            foreach (var product_stock in product_Stocks)
            {
                product_stock.Tovar = _context.Products.Find(product_stock.productID);
            }
            return product_Stocks;
        }

        // GET: api/Sklad_tov_OSTATKI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<int>> GetSklad_tov_OSTATKI(int id)
        {
            var sklad_tov_OSTATKI = await _context.Product_Stock.Where(p=>p.productID == id).FirstOrDefaultAsync();

            if (sklad_tov_OSTATKI == null)
            {
                return NotFound();
            }

            return sklad_tov_OSTATKI.total_stock;
        }

        [HttpGet]
        [Route("categ/{id}")]
        public async Task<ActionResult<IEnumerable<Product_stock>>> GetSklad_tov_OSTATKIByCateg(int id)
        {
            _context.Categories.Where(p => p.ID == id).Load();
            _context.Products.Where(p=>p.categoryID == id).Load();
            _context.Contractors.Load();
            _context.Manufactures.Load();
            var product_Stocks = await _context.Product_Stock.Where(p => p.Tovar != null && p.Tovar.categoryID == id).ToListAsync();

            if (product_Stocks == null)
            {
                return NotFound();
            }

            foreach (var product_stock in product_Stocks)
            {
                product_stock.Tovar = _context.Products.Find(product_stock.productID);
            }
            return product_Stocks;
        }
    }
}
