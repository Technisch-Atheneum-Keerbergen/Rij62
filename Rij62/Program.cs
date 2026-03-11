using Microsoft.EntityFrameworkCore;
using Rij62.Data;
using Rij62.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
           .UseSnakeCaseNamingConvention());
builder.Services.AddControllers();
builder.Services.AddScoped<LocalizationService>();

var app = builder.Build();

app.MapControllers();

app.Run();