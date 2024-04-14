using Microsoft.IdentityModel.Tokens;
using RestaurantTP.Models.Authentication;
using RestaurantTP.Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RestaurantTP.Service
{
    public class JWTService : IJWTService
    {

        public string GenerateToken(string name)
        {

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, name) };

            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
                );
  
            return new JwtSecurityTokenHandler().WriteToken(jwt);

            
        }

    }
}
