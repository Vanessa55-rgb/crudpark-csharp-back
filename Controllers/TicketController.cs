using CrudParking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudParking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TicketController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> Index()
        {
            return await _context.Tickets.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetById(int id)
        {
            var Tickets = await _context.Tickets.FindAsync(id);
            if (Tickets == null)
                return NotFound();
            return Tickets;
        }

        [HttpPost]
        public async Task<ActionResult<Ticket>> Create(Ticket Tickets)
        {
            _context.Tickets.Add(Tickets);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = Tickets.ID }, Tickets);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Ticket Tickets)
        {
            if (id != Tickets.ID)
                return BadRequest();

            _context.Entry(Tickets).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Tickets = await _context.Tickets.FindAsync(id);
            if (Tickets == null)
                return NotFound();

            _context.Tickets.Remove(Tickets);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}