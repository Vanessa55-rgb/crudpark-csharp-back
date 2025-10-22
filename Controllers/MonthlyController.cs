using CrudParking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudParking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonthlyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MonthlyController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Monthly>>> GetAll()
        {
            var monthlies = await _context.Monthlies
                .Include(m => m.VehicleMonthly)
                .ToListAsync();

            return Ok(monthlies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Monthly>> GetById(int id)
        {
            var monthly = await _context.Monthlies
                .Include(m => m.VehicleMonthly)
                .FirstOrDefaultAsync(m => m.ID == id);

            return monthly == null ? NotFound() : Ok(monthly);
        }

        [HttpPost]
        public async Task<ActionResult<Monthly>> Create(Monthly monthly)
        {
            _context.Monthlies.Add(monthly);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = monthly.ID }, monthly);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Monthly monthly)
        {
            if (id != monthly.ID) return BadRequest();

            _context.Entry(monthly).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var monthly = await _context.Monthlies.FindAsync(id);
            if (monthly == null) return NotFound();

            _context.Monthlies.Remove(monthly);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}