using Microsoft.IdentityModel.Tokens;
using RestaurantTP.Models.Authentication;
using RestaurantTP.Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RestaurantTP.Service
{
    public class JWTService : IJWTService
    {
        public readonly IRoleService _roleService;
        public JWTService(IRoleService roleService) 
        {
            _roleService = roleService;
        }
        public string GenerateToken(string name, string role)
        {
            var claims = new List<Claim>
    {
        new Claim(ClaimsIdentity.DefaultNameClaimType, name),
        new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
    };

            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.Now.AddSeconds(20),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }


    }
}
