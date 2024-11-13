using Jwt.AuthenticationManagen;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using Persistence.Database;
using Security.Api.Security;

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

var key = builder.Configuration.GetValue<string>("ApiSettings:secret");


builder.Services.TryAddSingleton<ISystemClock, SystemClock>();

//---- llamando la authentication autenticacion--
builder.Services.AddCustomJWTAuthentication();

//--------Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PersistenceDatabase>(options => options.UseSqlServer());

var app = builder.Build();

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

app.Run();
