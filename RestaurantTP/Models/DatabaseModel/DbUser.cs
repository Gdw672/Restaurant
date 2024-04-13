using System.ComponentModel.DataAnnotations;

namespace RestaurantTP.Models.DatabaseModel
{
    public class DbUser
    {
        public int Id { get; set; }
        public string name { get; set; } = "";
        public string password { get; set; } = "";
        public string role { get; set; } = "";
    }
}
