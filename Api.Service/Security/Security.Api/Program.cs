using Common.Utility;
using Jwt.AuthenticationManagen;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using Persistence.Database;
using Security.Api.Security;
using System.Net.WebSockets;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//-------Configuracion los permisos para que otros navegadores puedan consumir--
builder.Services.AddCorsApp();

//--------Configuracion Inyeccion Independecnia
builder.Services.ConfigureDI("");

builder.Services.AddMemoryCache();

//---- Configuracion los controladores para la autenticacion--
builder.Services.AddControllers(op =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    op.Filters.Add(new AuthorizeFilter(policy));
});


builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Ingresar Bearer [space] tuToken \r\n\r\n " +
                      "Ejemplo: Bearer 123456abcder",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id= "Bearer"
                },
                Scheme = "oauth2",
                Name="Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

builder.Services.TryAddSingleton<ISystemClock, SystemClock>();

//---- llamando la authentication autenticacion--
builder.Services.AddCustomJWTAuthentication();

//--------Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PersistenceDatabase>(options => options.UseSqlServer());

var app = builder.Build();

//Configurar opciones para WebSocket
var webSocketOptions = new WebSocketOptions
                       {
                           KeepAliveInterval = TimeSpan.FromMinutes(2)
                       };

// Habilitar el soporte de WebSocket
app.UseWebSockets(webSocketOptions);

// Middleware de WebSocket
app.Map("/ws", async context =>
{
    if (context.WebSockets.IsWebSocketRequest)
    {
        var webSocket = await context.WebSockets.AcceptWebSocketAsync();
        await WebSocketHandler.HandleWebSocketCommunication(context, webSocket);
    }
    else
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
    }
});

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseRouting();
app.UserCoreApp();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

await app.RunAsync();
