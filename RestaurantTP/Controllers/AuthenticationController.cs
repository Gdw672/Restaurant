using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantTP.Service.Interface;

namespace RestaurantTP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ICheckLoginService _checkLoginService;

        public AuthenticationController(ICheckLoginService checkLoginService)
        {
            _checkLoginService = checkLoginService;
        }
        [HttpGet]
        [Route("gettest")]
        public IActionResult GetData()
        {
            var data = new { Message = "Hello from ASP.NET Core Web API" };
            return Ok(data);
        }

        [HttpPost]
        [Route("sendData")]
        public IActionResult TryLogin([FromBody] AutRequest autRequest)
        {
            var validate = _checkLoginService.Login(autRequest);

            return Ok(validate);
        }
        public record AutRequest(string name, string password);
    }
}
