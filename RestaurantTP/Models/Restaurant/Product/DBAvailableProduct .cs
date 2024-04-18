using Microsoft.AspNetCore.Routing.Constraints;
using RestaurantTP.Models.Restaurant.Product;

    public class DBAvailableProduct : ProductBase
    {

    public DBAvailableProduct(string name, float quantity)
    {
        this.Name = name;
        this.quantity = quantity;
    }

    public float quantity { get; set; }
    
    }
