using Microsoft.AspNetCore.Mvc;
using RestaurantTP.Service.Interface;
using System.Globalization;
using System.Text.Json;

namespace RestaurantTP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookController : ControllerBase
    {
        private IDishService _dishService;
        public CookController(IDishService dishService) 
        {
         _dishService = dishService;
        }
        [HttpPost]
        [Route("addDish")]
        public IActionResult AddDish([FromBody] JsonElement dictionaryList)
        {
            var name = dictionaryList.GetProperty("name").GetString();

            var ingridients = new Dictionary<string, double>();

            foreach (var item in dictionaryList.GetProperty("ingridients").EnumerateArray())
            {
                string ingridientName = item.GetProperty("name").GetString();
                string ingridientAmount = item.GetProperty("amount").GetString();

                ingridients.Add(ingridientName, Convert.ToDouble(ingridientAmount, CultureInfo.InvariantCulture));
            }

            var validate = _dishService.CreateDish(name, ingridients);

            return Ok(validate);
        }

        public class Dish
        {
            public string Name { get; set; }
            public Dictionary<string, float> Ingredients { get; set; }
        }

    }
}
