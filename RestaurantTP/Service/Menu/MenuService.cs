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

        public void SetDailyMenu(List<string> dishList)
        {
            _restaurantTPDbContext.ClearAll(_restaurantTPDbContext.dailyMenuDishes);

            foreach (var d in dishList)
            {
                var dish = new DBDailyMenuDish(d);

                _restaurantTPDbContext.dailyMenuDishes.Add(dish);
            }

            _restaurantTPDbContext.SaveChanges();
        }
    }
}
