using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantTP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetData()
        {
            var data = new { Message = "Hello from ASP.NET Core Web API" };
            return Ok(data);
        }

        public record AutRequest(string name, string password);

    }
}
