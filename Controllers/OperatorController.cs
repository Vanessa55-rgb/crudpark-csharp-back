using CrudParking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudParking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperatorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OperatorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Operator>>> GetAll()
        {
            return Ok(await _context.Operators.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Operator>> GetById(int id)
        {
            var op = await _context.Operators.FindAsync(id);
            return op == null ? NotFound() : Ok(op);
        }

        [HttpPost]
        public async Task<ActionResult<Operator>> Create(Operator op)
        {
            _context.Operators.Add(op);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = op.ID }, op);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Operator op)
        {
            if (id != op.ID) return BadRequest();

            _context.Entry(op).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var op = await _context.Operators.FindAsync(id);
            if (op == null) return NotFound();

            _context.Operators.Remove(op);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}