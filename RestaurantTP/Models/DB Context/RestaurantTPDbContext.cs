using Microsoft.EntityFrameworkCore;
using RestaurantTP.Models.DatabaseModel;

namespace RestaurantTP.Database.Context
{
    public class RestaurantTPDbContext : DbContext
    {
        public DbSet<DbUser> users {  get; set; }

        public RestaurantTPDbContext(DbContextOptions<RestaurantTPDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = NANOMACHINE; Database = RestaurantTP; Trusted_Connection=True; TrustServerCertificate=true;");
        }
    }
}