namespace RestaurantTP.Service.Interface
{
    public interface IJWTService
    {
        public string GenerateToken(string name);
    }
}
