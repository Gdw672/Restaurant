using System.ComponentModel.DataAnnotations;

namespace RestaurantTP.Models.Order
{
    public class DBOrderComponent
    {
        [Key]
        public int ID { get; set; }
        public string DishName { get; set; } = "";
        public int OrderID { get; set; }
    }
}
