using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CrudParking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("status")]
        public IActionResult Status()
        {
            return Ok(new
            {
                message = "🚀 CRUDPark API is running successfully!",
                environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"
            });
        }

        [HttpGet("error")]
        public IActionResult Error()
        {
            var traceId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return Problem(
                title: "Internal Server Error",
                detail: "An unexpected error occurred in the server.",
                instance: traceId
            );
        }
    }
}