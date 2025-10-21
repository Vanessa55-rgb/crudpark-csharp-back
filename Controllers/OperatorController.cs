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
        public async Task<ActionResult<IEnumerable<Operator>>> Index()
        {
            return await _context.Operators.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Operator>> GetById(int id)
        {
            var Operators = await _context.Operators.FindAsync(id);
            if (Operators == null)
                return NotFound();
            return Operators;
        }

        [HttpPost]
        public async Task<ActionResult<Operator>> Create(Operator Operators)
        {
            _context.Operators.Add(Operators);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = Operators.ID }, Operators);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Operator Operators)
        {
            if (id != Operators.ID)
                return BadRequest();

            _context.Entry(Operators).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Operators = await _context.Operators.FindAsync(id);
            if (Operators == null)
                return NotFound();

            _context.Operators.Remove(Operators);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}