using Microsoft.EntityFrameworkCore;
using RestaurantTP.Models.DatabaseModel;
using RestaurantTP.Models.Order;
using RestaurantTP.Models.Restaurant.Dish;
using RestaurantTP.Models.Restaurant.Product;

namespace RestaurantTP.Models.DB_Context.Interface
{
    public interface IRestaurantTPDbContext
    {
        public void SaveChanges();
        public void ClearAll<TEntity>(DbSet<TEntity> dbSet) where TEntity : class;
        public DbSet<DbUser> users { get; set; }
        public DbSet<DBAvailableProduct> availableProducts { get; set; }
        public DbSet<DBProductToBuy> productsToBuy { get; set; }
        public DbSet<DBDish> dishes { get; set; }
        public DbSet<DBDailyMenuDish> dailyMenuDishes { get; set; }
        public DbSet<DBDishIngridient> ingredients { get; set; }
        public DbSet<DBOrder> orders { get; set; }
        public DbSet<DBOrderComponent> orderComponents { get; set; }
    }
}
