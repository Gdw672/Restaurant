using Microsoft.AspNetCore.Mvc;
using RestaurantTP.Service.Interface;
using System.Text.Json;

namespace RestaurantTP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMenuService _menuService;

        public AdminController(IProductService productService, IMenuService menuService)
        {
            _productService = productService;
            _menuService = menuService;
        }

        [HttpGet]
        [Route("getProductsToBuy")]
        public IActionResult GetProductsToBuy()
        {
            var productList = _productService.GetProductsToBuy();
            return Ok(productList);
        }

        [HttpPost]
        [Route("makeOrder")]
        public IActionResult GetProductsToSell([FromBody] JsonElement orderedProducts)
        {
            var allElements = new Dictionary<string, int>();

            foreach (var property in orderedProducts.EnumerateObject())
            {
                string key = property.Name;
                int value = int.Parse(property.Value.ToString());

                allElements.Add(key, value);
            }

            _productService.AddToAvailebaleProducts(allElements);

            return Ok(allElements);
        }

        [HttpGet]
        [Route("getDishList")]
        public IActionResult GetMenuList()
        {
           var dishList = _menuService.GetAllDishes();
            return Ok(dishList);
        }
    }
}
