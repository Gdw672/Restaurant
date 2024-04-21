using RestaurantTP.Models.DB_Context.Interface;
using RestaurantTP.Models.Restaurant.Dish;
using RestaurantTP.Service.Interface;

namespace RestaurantTP.Service.Menu
{
    public class MenuService : IMenuService
    {
        private IRestaurantTPDbContext _restaurantTPDbContext;
        public MenuService( IRestaurantTPDbContext restaurantTPDbContext)
        {
            _restaurantTPDbContext = restaurantTPDbContext;
        }
        public List<DBDish> GetAllDishes()
        {
            return _restaurantTPDbContext.dishes.ToList();
        }
    }
}
