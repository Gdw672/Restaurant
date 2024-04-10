using Microsoft.AspNetCore.Mvc;

namespace Restaraunt.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var data = new { Message = "Hello from ASP.NET Core Web API" };
            return Ok(data);
        }
    }
