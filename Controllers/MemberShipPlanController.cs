using CrudParking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudParking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembershipPlanController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MembershipPlanController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MembershipPlan>>> GetAll()
        {
            return Ok(await _context.MembershipPlans.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<MembershipPlan>> Create(MembershipPlan plan)
        {
            _context.MembershipPlans.Add(plan);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = plan.ID }, plan);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var plan = await _context.MembershipPlans.FindAsync(id);
            if (plan == null) return NotFound();

            _context.MembershipPlans.Remove(plan);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}