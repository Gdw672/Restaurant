using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestaurantTP.Database.Context;
using RestaurantTP.Models.Authentication;
using RestaurantTP.Models.DB_Context;
using RestaurantTP.Models.DB_Context.Interface;
using RestaurantTP.Service;
using RestaurantTP.Service.Authentication;
using RestaurantTP.Service.Dish;
using RestaurantTP.Service.Financial;
using RestaurantTP.Service.Interface;
using RestaurantTP.Service.Menu;
using RestaurantTP.Service.Order;
using RestaurantTP.Service.Product;

var builder = WebApplication.CreateBuilder(args);

        var Origins = "restaraunt-react-ap";

        builder.Services.AddTransient<ICheckLoginService, CheckLoginService>();
        builder.Services.AddTransient<IRestaurantTPDbContext, RestaurantTPDbContext>();
        builder.Services.AddTransient<IJWTService, JWTService>();
        builder.Services.AddTransient<IRoleService, RoleService>();
        builder.Services.AddTransient<IProductService, ProductService>();
        builder.Services.AddTransient<IDishService, DishService>();
        builder.Services.AddTransient<IMenuService, MenuService>();
        builder.Services.AddTransient<IOrderService, OrderService>();
        builder.Services.AddTransient<IFinancialService, FinancialService>();

        builder.Services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<RestarauntTPDBIdentityDBContext>();

        builder.Services.AddAuthorization();
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = AuthOptions.ISSUER,
                    ValidateAudience = true,
                    ValidAudience = AuthOptions.AUDIENCE,
                    ValidateLifetime = true,
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                    ValidateIssuerSigningKey = true,
                };
            });

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddSwaggerGen();
        builder.Services.AddCors(options =>
            options.AddPolicy(Origins, policy =>
            {
                policy.WithOrigins("http://localhost:5115/").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                policy.WithOrigins("http://localhost:3000/").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                policy.WithOrigins("http://localhost:3001/").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                policy.WithOrigins("http://localhost:3002/").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                policy.WithOrigins("http://localhost:3003/").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                policy.WithOrigins("http://localhost:3004/").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                policy.WithOrigins("http://localhost:3005/").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                policy.WithOrigins("http://localhost:3006/").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                policy.WithOrigins("http://localhost:3007/").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();

            }));

        builder.Services.AddDbContext<RestaurantTPDbContext>(options => options.UseSqlServer("Server = NANOMACHINE; Database = RestaurantTP; Trusted_Connection=True; TrustServerCertificate=true;"));
        builder.Services.AddDbContext<RestarauntTPDBIdentityDBContext>(options => options.UseSqlServer("Server = NANOMACHINE; Database = RestaurantTP; Trusted_Connection=True; TrustServerCertificate=true;"));

var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.UseCors(Origins);
app.MapControllers();

app.Run();