using RestaurantTP.Models.DB_Context.Interface;
using RestaurantTP.Service.Interface;
using static RestaurantTP.Controllers.AuthenticationController;

namespace RestaurantTP.Service
{
    public class CheckLoginService : ICheckLoginService
    {
        private readonly IRestaurantTPDbContext _restaurantTPDbContext;


        public CheckLoginService(IRestaurantTPDbContext restaurantTPDbContext)
        {
            _restaurantTPDbContext = restaurantTPDbContext;
        }

        public bool Login(AutRequest autRequest)
        {
            var users = _restaurantTPDbContext.users.ToList();

            var response = users.FirstOrDefault(user => autRequest.name == user.name && autRequest.password == user.password);

            if (response == null)
            {
                return false;
            }

            return true;
        }
    }
}
