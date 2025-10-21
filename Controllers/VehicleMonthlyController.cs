using CrudParking.Models;
namespace CrudParking.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
    public async Task<ActionResult<IEnumerable<VehicleMonthly>>> Index()
    {
        return await _context.VehiclesM.ToListAsync();
    }

    [HttpPost("{id}")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult<VehicleMonthly>> GetById(int id)
    {
        var vm = await _context.VehiclesM.FindAsync();
        if (vm == null)
        {
            return NotFound();
        }
        return vm;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult<VehicleMonthly>> Create(VehicleMonthly vh)
    {
            _context.VehiclesM.Add(vh);
            _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = vh.ID }, vh);
    }

    [HttpPut("{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, VehicleMonthly vh)
    {
        _context.Entry(vh).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var vh = await _context.VehiclesM.FindAsync(id);
        if (vh == null) return NotFound();

        _context.VehiclesM.Remove(vh);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}