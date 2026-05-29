using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Rij62.Data;
using Rij62.Services;

var builder = WebApplication.CreateBuilder(args);

var corsPolicy = "_mainCorsPolicy";


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicy,
                      policy =>
                      {
                          var frontendOrigin = builder.Configuration.GetValue<string>("FrontendOrigin");
                          var configOrigins = (builder.Configuration.GetValue<string>("Cors:ExtraAllowedOrigins") ?? "").Split(",");


                          string[] origins = new string[configOrigins.Length + (frontendOrigin != null ? 1 : 0)];
                          if (frontendOrigin != null)
                          {
                              origins[0] = frontendOrigin;
                          }
                          configOrigins.CopyTo(origins, 1);

                          policy.WithOrigins(origins)
                              .AllowAnyHeader()
                              .AllowAnyMethod(); // CRUD
                      });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
           .UseSnakeCaseNamingConvention());
builder.Services.AddControllers();
builder.Services.AddScoped<LocalizationService>();
builder.Services.AddScoped<MenuPresetService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<OrderValidationService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<OrderEventsWebsocketService>();
builder.Services.AddScoped<PaymentService>();

builder.Services.AddSingleton<UrlService>();
builder.Services.AddSingleton<JwtGenService>();

builder.Services.AddHostedService<PaymentRecoveryService>();
builder.Services.AddHttpClient<BancontactService>();
builder.Services.AddSingleton<BancontactService>();
builder.Services.AddSingleton<OrderEventsService>();


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
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {

                if (context.HttpContext.WebSockets.IsWebSocketRequest &&
                    context.Request.Headers.TryGetValue("Sec-WebSocket-Protocol", out var values))
                {
                    var parts = values.ToString().Split(',', 2);

                    if (parts.Length == 2)
                    {
                        context.Token = parts[1].Trim();
                    }
                }
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireClaim("isAdmin", "True"));
});


var app = builder.Build();

app.UseRouting();
app.UseWebSockets();

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

app.UseCors(corsPolicy);


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
