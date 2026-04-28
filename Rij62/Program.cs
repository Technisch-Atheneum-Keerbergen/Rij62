using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Rij62.Data;
using Rij62.Services;

var builder = WebApplication.CreateBuilder(args);

var DebugCorsPolicy = "_debug";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: DebugCorsPolicy,
                      policy =>
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
builder.Services.AddScoped<MenuPresetService>();
builder.Services.AddSingleton<JwtGenService>();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("Jwt:IssuerSigningKey")))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireClaim("isAdmin", "True"));
});


var app = builder.Build();

app.UseRouting();

//Print all registered routes for debugging
// Go to http://localhost:5148/routes to see the list of routes
app.MapGet("/routes", (IEnumerable<EndpointDataSource> sources) =>
{
    var routes = sources
        .SelectMany(s => s.Endpoints)
        .OfType<RouteEndpoint>()
        .Select(e => e.RoutePattern.RawText);

    return routes;
});

app.UseCors(DebugCorsPolicy);


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
