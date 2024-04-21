using System.ComponentModel.DataAnnotations;

namespace RestaurantTP.Models.Restaurant.Product
{
    public class ProductBase
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
    }
}
