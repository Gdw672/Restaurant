using Microsoft.AspNetCore.Http.HttpResults;
using RestaurantTP.Models.DB_Context.Interface;
using RestaurantTP.Models.Restaurant.Product;
using RestaurantTP.Service.Interface;

namespace RestaurantTP.Service.Product
{
    public class ProductService : IProductService
    {
        private readonly IRestaurantTPDbContext _restaurantTPDbContext;
        public ProductService(IRestaurantTPDbContext restaurantTPDbContext)
        {
         _restaurantTPDbContext = restaurantTPDbContext;
        }

        public List<DBProductToBuy> GetProductsToBuy()
        {
            var productsToBuy = _restaurantTPDbContext.productsToBuy;

            var list = productsToBuy.ToList();

            return list;
        }

        public float AddToAvailebaleProducts(Dictionary<string, int> products)
        {
            var availebaleProducts = _restaurantTPDbContext.availableProducts.ToList();

            foreach (var product in products) 
            {
                var existingProduct = availebaleProducts.FirstOrDefault(p => p.Name == product.Key);

                if(existingProduct != null)
                {
                    existingProduct.quantity += product.Value;
                }

                else
                {
                    var newProduct = new DBAvailableProduct(product.Key, product.Value);
                    availebaleProducts.Add(newProduct);
                }

                _restaurantTPDbContext.SaveChanges();
            }
            return 0;
        }
    }
}
