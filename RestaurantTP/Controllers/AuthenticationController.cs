using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantTP.Models.Static;
using RestaurantTP.Service.Interface;

namespace RestaurantTP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ICheckLoginService _checkLoginService;
        private readonly IRoleService _roleService;

        public AuthenticationController(ICheckLoginService checkLoginService, IRoleService roleService)
        {
            _checkLoginService = checkLoginService;
            _roleService = roleService;
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
        public async Task<IActionResult> TryLogin([FromBody] AutRequest autRequest)
        {
           await _roleService.SetRoles();

            var validate = _checkLoginService.Login(autRequest);

            return Ok(validate);
        }

        [HttpGet]
        [Authorize]
        [Route("getSecretInfo")]
        public IActionResult GetSecretInfo()
        {
            return Ok("QWERTY");
        }

        public record AutRequest(string name, string password);
    }
}
