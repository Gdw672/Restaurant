using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RestaurantTP.Service.Interface;

namespace RestaurantTP.Service.Authentication
{
    public class RoleService : IRoleService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public RoleService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task SetRoles()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                string[] roleNames = { "administrator", "cook", "waiter" };

                foreach (var roleName in roleNames)
                {
                    bool roleExists = await roleManager.RoleExistsAsync(roleName);
                    if (!roleExists)
                    {
                        await roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }
            }
        }
    }

}
