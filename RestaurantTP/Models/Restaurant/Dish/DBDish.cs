using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RestaurantTP.Models.Restaurant.Dish
{
    public class DBDish
    {
        public DBDish()
        {

        }

        public DBDish(string name)
        {
            Name = name;
        }

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
