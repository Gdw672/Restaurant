namespace RestaurantTP.Service.Interface
{
    public interface IDishService
    {
        public bool CreateDish(string name, Dictionary<string, double> ingridients);  
    }
}
