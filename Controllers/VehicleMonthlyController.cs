using CrudParking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudParking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleMonthlyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VehicleMonthlyController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleMonthly>>> GetAll()
        {
            return Ok(await _context.VehiclesM.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleMonthly>> GetById(int id)
        {
            var vehicle = await _context.VehiclesM.FindAsync(id);
            return vehicle == null ? NotFound() : Ok(vehicle);
        }

        [HttpPost]
        public async Task<ActionResult<VehicleMonthly>> Create(VehicleMonthly vehicle)
        {
            _context.VehiclesM.Add(vehicle);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = vehicle.ID }, vehicle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, VehicleMonthly vehicle)
        {
            if (id != vehicle.ID) return BadRequest();

            _context.Entry(vehicle).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicle = await _context.VehiclesM.FindAsync(id);
            if (vehicle == null) return NotFound();

            _context.VehiclesM.Remove(vehicle);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}