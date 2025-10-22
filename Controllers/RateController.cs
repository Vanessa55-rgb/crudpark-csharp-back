using CrudParking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudParking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RateController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RateController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rate>>> GetAll()
        {
            return Ok(await _context.Rates.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rate>> GetById(int id)
        {
            var rate = await _context.Rates.FindAsync(id);
            return rate == null ? NotFound() : Ok(rate);
        }

        [HttpPost]
        public async Task<ActionResult<Rate>> Create(Rate rate)
        {
            _context.Rates.Add(rate);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = rate.ID }, rate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Rate rate)
        {
            if (id != rate.ID) return BadRequest();

            _context.Entry(rate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rate = await _context.Rates.FindAsync(id);
            if (rate == null) return NotFound();

            _context.Rates.Remove(rate);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}