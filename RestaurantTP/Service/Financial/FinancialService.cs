using RestaurantTP.Models.DB_Context.Interface;
using RestaurantTP.Models.Financial;
using RestaurantTP.Service.Interface;

namespace RestaurantTP.Service.Financial
{
    public class FinancialService : IFinancialService
    {
        private IRestaurantTPDbContext _restaurantTPDbContext;
        public FinancialService(IRestaurantTPDbContext restaurantTPDbContext)
        { 
            _restaurantTPDbContext = restaurantTPDbContext;
        }
        public void PlusProfitFromSoltDish(double profit)
        {
           var profits = _restaurantTPDbContext.dayProfits.ToList();

           var todayProfit = profits.FirstOrDefault(day => day.Date == DateTime.Today);

            if (todayProfit != null)
            {
                todayProfit.DayProfit += profit;
            }
            else
            {
                DBDayProfit dayProfit = new DBDayProfit(DateTime.Today, profit);
                _restaurantTPDbContext.dayProfits.Add(dayProfit);
            }
            _restaurantTPDbContext.SaveChanges();
        }
    }
}
