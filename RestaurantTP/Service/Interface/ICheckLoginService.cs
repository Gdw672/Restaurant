using static RestaurantTP.Controllers.AuthenticationController;

namespace RestaurantTP.Service.Interface
{
    public interface ICheckLoginService
    {
        public bool Login(AutRequest autRequest);
    }
}
