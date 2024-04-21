﻿using Microsoft.EntityFrameworkCore;
using RestaurantTP.Migrations;
using RestaurantTP.Models.DB_Context.Interface;
using RestaurantTP.Models.Restaurant.Dish;
using RestaurantTP.Service.Interface;

namespace RestaurantTP.Service.Dish
{
    public class DishService : IDishService
    {
        private IRestaurantTPDbContext _restaurantTPDbContext;
        public DishService(IRestaurantTPDbContext restaurantTPDbContext) 
        {
        _restaurantTPDbContext = restaurantTPDbContext;
        }

        public bool CreateDish(string name, Dictionary<string, double> ingridients)
        {
            AddDish(name);

            AddIngridients(name, ingridients);
            
            return true;
        }

        private void AddDish(string name)
        {
            var newDish = new DBDish(name);

            _restaurantTPDbContext.dishes.Add(newDish);

            _restaurantTPDbContext.SaveChanges();
        }

        private void AddIngridients(string name, Dictionary<string, double> ingridients)
        {
            var existingDishID = _restaurantTPDbContext.dishes.FirstOrDefault(dish => dish.Name == name).ID;

            foreach (var keyObject in ingridients)
            {
                if(_restaurantTPDbContext.productsToBuy.FirstOrDefault(ingridient => ingridient.Name == keyObject.Key) is not null)
                {
                    var ingridient = new DBDishIngridient(keyObject.Key, keyObject.Value, existingDishID);
                    _restaurantTPDbContext.ingridients.Add(ingridient);
                }
                else
                {
                    var wrongDish = _restaurantTPDbContext.dishes.FirstOrDefault(dish => dish.Name == name);
                    _restaurantTPDbContext.dishes.Remove(wrongDish);
                    
                    throw new Exception("The ingredient is out of stock or does not exist. Please contact the administrator or correct the recipe.");
                }
            }

            _restaurantTPDbContext.SaveChanges();
        }
    }
}
