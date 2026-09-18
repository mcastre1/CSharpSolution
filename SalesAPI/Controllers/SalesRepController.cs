using Microsoft.AspNetCore.Mvc;
using SalesAPI.Data;
using Microsoft.EntityFrameworkCore;
using SalesAPI.Models;
using SalesAPI.Dtos;

namespace SalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesRepController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SalesRepController(AppDbContext context)
        {
            _context = context;
        }

        // Get: api/salesreps
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var salesReps = await _context.SalesReps.ToListAsync();
            return Ok(salesReps);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalesRep(int id)
        {
            var salesrep = await _context.SalesReps.FindAsync(id);

            if(salesrep == null)
            {
                return NotFound();
            }

            return Ok(salesrep);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesRep(int id, SalesRepPutDto salesrepdto)
        {
            var existingSalesRep = await _context.SalesReps.FindAsync(id);

            if (existingSalesRep == null)
            {
                return NotFound();
            }

            existingSalesRep.FirstName = salesrepdto.FirstName;
            existingSalesRep.LastName = salesrepdto.LastName;

            await _context.SaveChangesAsync();

            return NoContent();
        }   

        [HttpPost]
        public async Task<IActionResult> CreateSalesRep(SalesRepCreateDto salesrepdto)
        {
            var newSalesRep = new SalesRep
            {
                FirstName = salesrepdto.FirstName,
                LastName = salesrepdto.LastName
            };

            _context.SalesReps.Add(newSalesRep);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesRep", new { id = newSalesRep.Id }, salesrepdto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesRep(int id)
        {
            var salesrep = await _context.SalesReps.FindAsync(id);

            if(salesrep == null)
            {
                return NotFound();
            }

            _context.SalesReps.Remove(salesrep);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalesRepExists(int id)
        {
            return _context.SalesReps.Any(s => s.Id == id);
        }

    }
}
