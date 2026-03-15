using Microsoft.EntityFrameworkCore;
using Rij62.Data;
using Rij62.Services;

var builder = WebApplication.CreateBuilder(args);

var DebugCorsPolicy="_debug";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: DebugCorsPolicy,
                      policy  =>
                      {
                          policy.WithOrigins("http://localhost:5173"); // frontend
                      });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
           .UseSnakeCaseNamingConvention());
builder.Services.AddControllers();
builder.Services.AddScoped<LocalizationService>();

var app = builder.Build();

app.UseCors(DebugCorsPolicy);

app.MapControllers();

app.Run();