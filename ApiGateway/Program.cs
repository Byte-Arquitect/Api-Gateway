using Microsoft.AspNetCore.Server.Kestrel.Core;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Cargar la configuración de Ocelot
builder.Configuration.AddJsonFile("ocelot.json" , optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile("userEndpoints.json" , optional: false, reloadOnChange: true); //User Service Endpoints
builder.Configuration.AddJsonFile("career.json" , optional: false, reloadOnChange: true); //Career Service Endpoints
builder.Configuration.AddJsonFile("access.json" , optional: false, reloadOnChange: true); //Acccess Service Endpoints
builder.Services.AddOcelot();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Information);

var app = builder.Build();

app.UseOcelot().Wait();

app.Run();