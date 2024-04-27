using Microsoft.AspNetCore.Routing.Constraints;
using RestaurantTP.Models.Restaurant.Product;

    public class DBAvailableProduct : ProductBase
    {

    public DBAvailableProduct(string name, double quantity)
    {
        this.Name = name;
        this.quantity = quantity;
    }

    public double quantity { get; set; }
    
    }
