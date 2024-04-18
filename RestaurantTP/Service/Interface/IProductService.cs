using RestaurantTP.Models.Restaurant.Product;

namespace RestaurantTP.Service.Interface
{
    public interface IProductService
    {
        public List<DBProductToBuy> GetProductsToBuy();

        public float AddToAvailebaleProducts(Dictionary<string, int> products);
    }
}
