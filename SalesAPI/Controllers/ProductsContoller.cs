using Microsoft.AspNetCore.Mvc;
using SalesAPI.Data;
using Microsoft.EntityFrameworkCore;
using SalesAPI.Models;
using SalesAPI.Dtos;

namespace SalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // Get: api/Products
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        // Get: api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


        // Put: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdcut(int id, ProductUpdateDto productdto)
        {

            var existingProduct = await _context.Products.FindAsync(id);

            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = productdto.Name;
            existingProduct.Price = productdto.Price;

            _context.Entry(existingProduct).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();

        }

        // Post: api/Products
        [HttpPost]
        public async Task<IActionResult> PostProduct(ProductCreateDto productdto)
        {
            var newProduct = new Product{
                Name = productdto.Name,
                Price = productdto.Price
            };

            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = newProduct.Id }, productdto);
        }

        // Delete: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();

        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
