using static RestaurantTP.Controllers.AuthenticationController;

namespace RestaurantTP.Service.Interface
{
    public interface ICheckLoginService
    {
        public object Login(AutRequest autRequest);
    }
}
