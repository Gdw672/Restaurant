namespace RestaurantTP.Models.Restaurant.Dish
{
    public class DBDishIngridient
    {
        public DBDishIngridient() { }

        public DBDishIngridient(string _name, double amount, int dishId)
        {
            IngredientName = _name;
            Amount = amount;
            DishId = dishId;
        }

        public int Id { get; set; }
        public string IngredientName { get; set; }
        public double Amount { get; set; }

        public int DishId { get; set; }
        public DBDish Dish { get; set; }
    }
}
