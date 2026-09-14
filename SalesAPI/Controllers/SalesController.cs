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

        [HttpPost]
        public async Task<IActionResult> CreateSale(Sale sale)
        {
            var newSale = new Sale
            {
                CustomerId = sale.CustomerId,
                SalesRepId = sale.SalesRepId,
                SaleDate = DateTime.UtcNow
            };

            _context.Sales.Add(newSale);
            await _context.SaveChangesAsync();

            foreach (var item in sale.SaleItems)
            {
                _context.SaleItems.Add(new SaleItem
                {
                    SaleId = newSale.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                });
            }

            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSale), new { id = newSale.Id }, newSale);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSale(int id, Sale sale)
        {
            if(id != sale.Id)
            {
                return BadRequest();
            }

            var existingSale = await _context.Sales.Include(s => s.SaleItems).FirstOrDefaultAsync(s => s.Id == id);

            if(existingSale == null)
            {
                return NotFound();
            }

            existingSale.CustomerId = sale.CustomerId;
            existingSale.SalesRepId = sale.SalesRepId;

            _context.SaleItems.RemoveRange(existingSale.SaleItems);

            foreach (var item in sale.SaleItems)
            {
                _context.SaleItems.Add(new SaleItem
                {
                    SaleId = existingSale.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                });
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            var existingSale = await _context.Sales.Include(s => s.SaleItems).FirstOrDefaultAsync(s => s.Id == id);

            if (existingSale == null)
            {
                return NotFound();
            }

            _context.SaleItems.RemoveRange(existingSale.SaleItems);
            _context.Sales.Remove(existingSale);

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
