using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SalesAPI.Data;

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
    }
}
