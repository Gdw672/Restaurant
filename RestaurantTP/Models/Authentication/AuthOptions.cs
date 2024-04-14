using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace RestaurantTP.Models.Authentication
{
    public class AuthOptions
    {
        public const string ISSUER = "RestaurantTP"; 
        public const string AUDIENCE = "restaraunt-react-ap";
        const string KEY = "mysupersecret_secretsecretsecretkey!123";  
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
