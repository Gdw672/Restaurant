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

        public DBDish(string name, double price, double profit)
        {
            Name = name;
            Price = price;
            Profit = profit;
        }

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Profit { get; set; }
    }
}
