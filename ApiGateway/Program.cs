using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Cargar la configuración de Ocelot


// Acceder a la configuración de JwtSettings
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var authority = jwtSettings["Authority"];
var audience = jwtSettings["Audience"];
var secretKey =
    jwtSettings["Key"] ?? throw new ArgumentNullException("Key", "SecretKey cannot be null");

// Configurar autenticación JWT
builder
    .Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true, // Valida que la clave de firma sea correcta
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)), // Debe coincidir con la clave usada para firmar el token
        };
    });

var files = new[] { "ocelot.json" };
foreach (var file in files)
{
    builder.Configuration.AddJsonFile(file, optional: false, reloadOnChange: true);
}

// Agregar los servicios de Ocelot
builder.Services.AddOcelot();

// Configurar logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Information);

// Configurar Kestrel para HTTP/2 con HTTPS


var app = builder.Build();

// Usar autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

app.UseOcelot().Wait();

app.Run();
