using Jwt.AuthenticationManagen;
using Persistence.Database.CurrentUser.Service;
using Security.Service.EventHandlers;
using Security.Service.Queries;

namespace Security.Api.Security
{
    public static class ContainerProvider
    {
        private static string _conexion;

        public static IServiceCollection ConfigureDI(
        this IServiceCollection services,
        string cadenaConexion)
        {
            _conexion = cadenaConexion;
            ConfigureContainer(services);
            return services;
        }

        private static void ConfigureContainer(IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddScoped<IRolQueryService, RolQueryService>();
            services.AddScoped<IRolEventHandlers, RolEventHandlers>();
            services.AddScoped<IUsuarioEventHandlers, UsuarioEventHandlers>();
            services.AddScoped<IUsuarioQueryService, UsuarioQueryService>();
            services.AddScoped<IPermisoQueryService, PermisoQueryService>();
            services.AddScoped<IPermisoEventHandlers, PermisoEventHandlers>();
            services.AddScoped<INavbarQueryService, NavbarQueryService>();
            services.AddScoped<INavbarEventHandlers, NavbarEventHandlers>();
            services.AddScoped<INavbarRelacionRolQueryService, NavbarRelacionRolQueryService>();

            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddSingleton(new JwtTokenHandler(_conexion));

        }
    }
}
