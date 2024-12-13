using Microsoft.AspNetCore.Server.Kestrel.Core;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var authority = jwtSettings["Authority"];
var audience = jwtSettings["Audience"];
var key = jwtSettings["MyKey"];
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(key, options =>
    {
        options.Authority = authority;
        options.Audience = audience;
    });


var files = new[] { "ocelot.json", "userEndpoints.json", "career.json","access.json", "appsettings.json" };
foreach (var file in files)
{
    builder.Configuration.AddJsonFile(file, optional: false, reloadOnChange: true);
}
builder.Services.AddOcelot();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Information);

var app = builder.Build();


app.UseOcelot().Wait();


app.Run();