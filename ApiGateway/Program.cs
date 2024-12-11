using Microsoft.AspNetCore.Server.Kestrel.Core;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Cargar la configuración de Ocelot
builder.Configuration.AddJsonFile("ocelot.json" , optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Information);

AppContext.SetSwitch("Microsoft.AspNetCore.Server.Kestrel.EnableWindows81Http2", true);
var app = builder.Build();

app.UseOcelot().Wait();

app.Run();