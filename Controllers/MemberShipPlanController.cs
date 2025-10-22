using Microsoft.AspNetCore.Mvc;
using CrudParking.Models;

namespace CrudParking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipPlanController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MembershipPlanController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var plans = _context.MembershipPlans.ToList();
            return Ok(plans);
        }
    }
}