using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var authority = jwtSettings["Authority"];
var audience = jwtSettings["Audience"];
var key = jwtSettings["MyKey"];
builder
    .Services.AddAuthentication("Bearer") // Usa el esquema Bearer
    .AddJwtBearer(
        key,
        options =>
        {
            options.Authority = authority; // Cambiar por la URL del servidor de autenticación
            options.Audience = audience; // Cambiar por tu audiencia válida (el receptor del token)
            options.RequireHttpsMetadata = false; // Cambiar a true en producción
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true, // Validar el emisor del token
                ValidateAudience = true, // Validar la audiencia
                ValidateLifetime = true, // Validar la expiración del token
                ValidateIssuerSigningKey = true, // Validar la clave de firma del token
            };
        }
    );
var files = new[]
{
    "ocelot.json",
    "userEndpoints.json",
    "career.json",
    "access.json",
    "appsettings.json",
};
foreach (var file in files)
{
    builder.Configuration.AddJsonFile(file, optional: false, reloadOnChange: true);
}
builder.Services.AddOcelot();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Information);

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseOcelot().Wait();

app.Run();
