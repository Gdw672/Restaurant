using Microsoft.EntityFrameworkCore;
using RestaurantTP.Models.DatabaseModel;

namespace RestaurantTP.Models.DB_Context.Interface
{
    public interface IRestaurantTPDbContext
    {
        public DbSet<DbUser> users { get; set; }
    }
}
