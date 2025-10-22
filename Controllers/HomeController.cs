using Microsoft.AspNetCore.Mvc;

namespace CrudParking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStatus()
        {
            return Ok(new
            {
                message = "🚗 CrudParking API is running successfully!",
                status = "online",
                version = "v1.0.0",
                environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production",
                serverTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") + " UTC",
                endpoints = new[]
                {
                    new { name = "Operators", url = "/api/operator" },
                    new { name = "Vehicles", url = "/api/vehicle" },
                    new { name = "Tickets", url = "/api/ticket" },
                    new { name = "Payments", url = "/api/pay" },
                    new { name = "Rates", url = "/api/rate" },
                    new { name = "Memberships", url = "/api/monthly" }
                }
            });
        }
    }
}