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
                        policy.WithOrigins("http://localhost:5173")
                            .AllowAnyHeader()
                            .AllowAnyMethod() // CRUD
                            .AllowCredentials(); // Oauth
                      });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
           .UseSnakeCaseNamingConvention());
builder.Services.AddControllers();
builder.Services.AddScoped<LocalizationService>();

// Oauth
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "Google";
})
.AddCookie()
.AddGoogle(options =>
{
    options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
});


var app = builder.Build();

app.UseRouting();

app.UseCors(DebugCorsPolicy);

// Oauth
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();