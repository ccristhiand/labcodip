using Laboratory.Service.EventHandlers;
using Laboratory.Service.Queries;
using Persistence.Database.CurrentUser.Service;

namespace Laboratory.Api.Security
{
    public static class ContainerProvider
    {
        public static IServiceCollection ConfigureDI(
        this IServiceCollection services)
        {
            ConfigureContainer(services);
            return services;
        }

        private static void ConfigureContainer(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IOrdenQueryService, OrdenQueryService>();
            services.AddScoped<IOrdenEventHandlers, OrdenEventHandlers>();
            services.AddScoped<IMedicoQueryService, MedicoQueryService>();
            services.AddScoped<IMedicoEventHandlers, MedicoEventHandlers>();
            services.AddScoped<IOrigenQueryService, OrigenQueryService>();
            services.AddScoped<IOrigenEventHandlers, OrigenEventHandlers>();
            services.AddScoped<IServicioQueryService, ServicioQueryService>();
            services.AddScoped<IServicioEventHandlers, ServicioEventHandlers>();
            services.AddScoped<IProcedenciaQueryService, ProcedenciaQueryService>();
            services.AddScoped<IProcedenciaEventHandlers, ProcedenciaEventHandlers>();
            services.AddScoped<IPersonaQueryService, PersonaQueryService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

        }
    }
}
