using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantTP.Database.Context;

namespace RestaurantTP.Models.DB_Context
{
    public class RestarauntTPDBIdentityDBContext : IdentityDbContext<IdentityUser>
    {
        public RestarauntTPDBIdentityDBContext(DbContextOptions<RestarauntTPDBIdentityDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = NANOMACHINE; Database = RestaurantTP; Trusted_Connection=True; TrustServerCertificate=true;");
        }
    }
}
