using Microsoft.AspNetCore.Mvc;
using RestaurantTP.Models.DB_Context.Interface;
using RestaurantTP.Service.Interface;
using static RestaurantTP.Controllers.AuthenticationController;

namespace RestaurantTP.Service
{
    public class CheckLoginService : ICheckLoginService
    {
        private readonly IRestaurantTPDbContext _restaurantTPDbContext;
        private readonly IJWTService _jwtService;


        public CheckLoginService(IRestaurantTPDbContext restaurantTPDbContext, IJWTService JWTservice)
        {
            _restaurantTPDbContext = restaurantTPDbContext;
            _jwtService = JWTservice;
        }

        public object Login(AutRequest autRequest)
        {
            var users = _restaurantTPDbContext.users.ToList();

            var logInfo = users.FirstOrDefault(user => autRequest.name == user.name && autRequest.password == user.password);

            if (logInfo == null)
            {
                return new
                {
                    name = string.Empty,
                    token = string.Empty,
                    acces = false
                };
            }

            var token =  _jwtService.GenerateToken(autRequest.name, logInfo.role);

            var response = new
            {
                name = autRequest.name,
                token = token,
                acces = true
            };

            return response;

        }
    }
}
