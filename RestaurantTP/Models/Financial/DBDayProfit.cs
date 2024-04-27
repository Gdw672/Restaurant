using System.ComponentModel.DataAnnotations;

namespace RestaurantTP.Models.Financial
{
    public class DBDayProfit
    {
        public DBDayProfit () { }

        public DBDayProfit (DateTime dateTime, double profit)
        {
            Date = dateTime;
            DayProfit = profit;
        }

        [Key]
        public int ID { get; set; }
        public double DayProfit { get; set; }
        public DateTime Date { get; set; }
    }
}
