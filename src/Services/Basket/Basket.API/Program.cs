using Basket.API.GRPCServices;
using Basket.API.Repository;
using Basket.API.SettingsConfiguration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddStackExchangeRedisCache(
    options =>
    {
        options.Configuration = "127.0.0.1:6379";
        //var settings = builder.Configuration.GetValue<CacheSettings>("CacheSettings") ?? new CacheSettings() { ConnectionString = "localhost:6379" };
        //options.Configuration = settings.ConnectionString;
    });
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<GRPCServicesClient>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();