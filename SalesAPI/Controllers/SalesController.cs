using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SalesAPI.Data;
using SalesAPI.Models;

namespace SalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public SalesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sales = await _context.Sales.Include(s => s.SaleItems).ToListAsync();
            return Ok(sales);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSale(int id)
        {
            var sale = await _context.Sales.Include(s => s.SaleItems).FirstOrDefaultAsync(s => s.Id == id);

            if (sale == null)
            {
                return NotFound();
            }

            return Ok(sale);

        }

        public async Task<IActionResult> CreateSale(Sale sale)
        {
            var newSale = new Sale
            {
                CustomerId = sale.CustomerId,
                SalesRepId = sale.SalesRepId,
                SaleDate = DateTime.UtcNow
            };
        }
    }
}
