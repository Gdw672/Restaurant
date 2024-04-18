using Microsoft.AspNetCore.Mvc;
using RestaurantTP.Service.Interface;
using System.Text.Json;

namespace RestaurantTP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService) 
        { 
            _productService = productService;
        }

        [HttpGet]
        [Route("getProductsToBuy")]
        public IActionResult GetProductsToBuy()
        {
            var productList =_productService.GetProductsToBuy();
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

        public record OrderedProducts(List<Product> orderedProducts);

        public record Product(string key, int value);



    }
}
