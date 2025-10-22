using CrudParking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudParking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PayController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PayController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pay>>> GetAll()
        {
            var pays = await _context.Pays
                .Include(p => p.Ticket)
                .Include(p => p.Operator)
                .ToListAsync();

            return Ok(pays);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pay>> GetById(int id)
        {
            var pay = await _context.Pays
                .Include(p => p.Ticket)
                .Include(p => p.Operator)
                .FirstOrDefaultAsync(p => p.ID == id);

            return pay == null ? NotFound() : Ok(pay);
        }

        [HttpPost]
        public async Task<ActionResult<Pay>> Create(Pay pay)
        {
            _context.Pays.Add(pay);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = pay.ID }, pay);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Pay pay)
        {
            if (id != pay.ID) return BadRequest();

            _context.Entry(pay).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pay = await _context.Pays.FindAsync(id);
            if (pay == null) return NotFound();

            _context.Pays.Remove(pay);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}