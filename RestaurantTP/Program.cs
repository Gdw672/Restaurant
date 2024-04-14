using Microsoft.EntityFrameworkCore;
using RestaurantTP.Database.Context;
using RestaurantTP.Models.DB_Context.Interface;
using RestaurantTP.Service;
using RestaurantTP.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

var Origins = "restaraunt-react-ap";
builder.Services.AddAuthentication("Bearer").AddJwtBearer();

builder.Services.AddTransient<ICheckLoginService, CheckLoginService>();
builder.Services.AddTransient<IRestaurantTPDbContext, RestaurantTPDbContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();

builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
    options.AddPolicy(Origins, policy =>
    {
        policy.WithOrigins("http://localhost:5115/").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
        policy.WithOrigins("http://localhost:3003/").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
        policy.WithOrigins("http://localhost:3004/").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
        policy.WithOrigins("http://localhost:3005/").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
        policy.WithOrigins("http://localhost:3006/").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
        policy.WithOrigins("http://localhost:3007/").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();

    }));

builder.Services.AddDbContext<RestaurantTPDbContext>(options => options.UseSqlServer("Server = NANOMACHINE; Database = RestaurantTP; Trusted_Connection=True; TrustServerCertificate=true;"));

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