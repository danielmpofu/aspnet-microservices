using Catalog.API.Data;
using Catalog.API.Repository;
using Catalog.API.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseProperties>(
    builder.Configuration.GetSection("DatabaseSettings"));


// Add services to the container.
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<ICatalogContext, CatalogContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
