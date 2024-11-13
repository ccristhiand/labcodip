using Jwt.AuthenticationManagen;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Persistence.Database;
using Report.Api.Security;

var builder = WebApplication.CreateBuilder(args);

//-------Configuracion los permisos para que otros navegadores puedan consumir--
builder.Services.AddCorsApp();

//--------Configuracion Inyeccion Independecnia
builder.Services.ConfigureDI();

//---- Configuracion los controladores para la autenticacion--
builder.Services.AddControllers(op =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    op.Filters.Add(new AuthorizeFilter(policy));
});

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