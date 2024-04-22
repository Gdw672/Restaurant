using System.ComponentModel.DataAnnotations;

namespace RestaurantTP.Models.Restaurant.Dish
{
    public class DBDailyMenuDish
    {
        public DBDailyMenuDish () { }

        public DBDailyMenuDish(string name)
        {
            Name = name;
        }

        [Key]
        public int ID { get; set; }
        public string Name { get; set; } = "";
    }
}
