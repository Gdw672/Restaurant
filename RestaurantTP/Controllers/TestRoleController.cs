using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantTP.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "waiter")]
    [ApiController]
    public class TestRoleController : ControllerBase
    {
        [HttpGet]
        [Route("getSecretInfo")]
        public IActionResult GetSecretInfo()
        {
            return Ok("QWERTY");
        }
    }
}
