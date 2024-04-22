using RestaurantTP.Models.Restaurant.Dish;

namespace RestaurantTP.Service.Interface
{
    public interface IMenuService
    {
        public List<DBDish> GetAllDishes();
        public void SetDailyMenu(List<string> dishList);
    }
}
