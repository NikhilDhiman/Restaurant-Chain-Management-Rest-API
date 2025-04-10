using RestaurantShop.RepositoryLayer;
using RestaurantShop.ServiceLayer;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRestaurantShopServiceLayer, RestaurantShopServiceLayer>();
builder.Services.AddScoped<IRestaurantShopRepositoryLayer, RestaurantShopRepositoryLayer>();

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

// Get Logger Instance
var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Application started successfully!");

app.Run();
