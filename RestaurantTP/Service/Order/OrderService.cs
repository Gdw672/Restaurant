using RestaurantTP.Models.DB_Context.Interface;
using RestaurantTP.Service.Interface;

namespace RestaurantTP.Service.Order
{
    public class OrderService : IOrderService
    {

        private IRestaurantTPDbContext dbContext;
        private IFinancialService financialService;
        public OrderService(IRestaurantTPDbContext _restaurantTPDbContext, IFinancialService _financialService)
        {
            dbContext = _restaurantTPDbContext;
            financialService = _financialService;
        }

        public void MakeOrders()
        {
            var orders = dbContext.orders.ToList();
            var ordersComponents = dbContext.orderComponents.ToList();

            foreach (var order in orders)
            {
                if(order.Status == Models.Order.EOrderStatus.inProgress)
                {
                    foreach (var component in ordersComponents)
                    {
                        if (component.OrderID == order.ID)
                        {
                            var name = component.DishName;
                            CountProducts(name);
                            order.Status = Models.Order.EOrderStatus.Done;
                        }
                    }
                }
            }
            dbContext.SaveChanges();
        }

        private void CountProducts(string dishName)
        {
            var dishes = dbContext.dishes.ToList();
            var ingredients = dbContext.ingredients.ToList();

            var dish = dishes.FirstOrDefault(dish => dish.Name == dishName);

            var ingredientsList = ingredients.FindAll(ing => ing.DishId == dish.ID);

            foreach (var item in ingredientsList)
            {
               var product = dbContext.availableProducts.FirstOrDefault(ingr => ingr.Name == item.IngredientName);

               product.quantity -= item.Amount;

                if(product.quantity < 0)
                {
                    product.quantity = 0;
                }
            }

            financialService.PlusProfitFromSoltDish(dish.Profit);

            dbContext.SaveChanges();
        }
    }
}
