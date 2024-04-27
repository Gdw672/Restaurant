using Microsoft.EntityFrameworkCore;
using RestaurantTP.Models.DatabaseModel;
using RestaurantTP.Models.DB_Context.Interface;
using RestaurantTP.Models.Financial;
using RestaurantTP.Models.Order;
using RestaurantTP.Models.Restaurant.Dish;
using RestaurantTP.Models.Restaurant.Product;

namespace RestaurantTP.Database.Context
{
    public class RestaurantTPDbContext : DbContext, IRestaurantTPDbContext
    {
        public DbSet<DbUser> users { get; set; }
        public DbSet<DBAvailableProduct> availableProducts { get; set; }
        public DbSet<DBProductToBuy> productsToBuy { get; set; }
        public DbSet<DBDish > dishes { get; set; }
        public DbSet<DBDailyMenuDish>  dailyMenuDishes { get; set; }
        public DbSet<DBDishIngridient> ingredients { get; set; }
        public DbSet<DBOrder> orders { get; set; }
        public DbSet<DBOrderComponent> orderComponents { get; set; }
        public DbSet<DBDayProfit> dayProfits { get; set; }

        public RestaurantTPDbContext(DbContextOptions<RestaurantTPDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = NANOMACHINE; Database = RestaurantTP; Trusted_Connection=True; TrustServerCertificate=true;");
        }

        public void SaveChanges()
        {
            base.SaveChanges();
        }

        public void ClearAll<TEntity>(DbSet<TEntity> dbSet) where TEntity : class
        {
            dbSet.RemoveRange(dbSet);
        }
       
    }
}