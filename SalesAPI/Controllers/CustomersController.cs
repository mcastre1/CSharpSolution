using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SalesAPI.Data;
using SalesAPI.Models;

namespace SalesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return Ok(customers);
        }
    }
}
