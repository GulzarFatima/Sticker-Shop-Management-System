using Microsoft.EntityFrameworkCore;
using StickerShopCMS.Data;
using StickerShopCMS.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ProductService>();


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<InventoryService>();
builder.Services.AddScoped<SaleItemService>();
builder.Services.AddScoped<SaleService>();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
