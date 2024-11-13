using Configuration.Service.EventHandlers;
using Configuration.Service.Queries;
using Configuration.Service.Queries.Query;
using Persistence.Database.CurrentUser.Service;

namespace Configuration.Api.Security
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
            services.AddScoped<IAreaEventHandlers, AreaEventHandlers>();
            services.AddScoped<IEquipoMedicoEventHandlers, EquipoMedicoEventHandlers>();
            services.AddScoped<IEquipoMedicoExamenEventHandlers, EquipoMedicoExamenEventHandlers>();
            services.AddScoped<IExamenEventHandlers, ExamenEventHandlers>();
            services.AddScoped<IHospitalEventHandlers, HospitalEventHandlers>();
            services.AddScoped<ILaboratorioEventHandlers, LaboratorioEventHandlers>();
            services.AddScoped<IPersonaEventHandlers, PersonaEventHandlers>();
            services.AddScoped<ISistemaClienteEventHandlers, SistemaClienteEventHandlers>();
            services.AddScoped<ISistemaClienteExamenEventHandlers, SistemaClienteExamenEventHandlers>();
            services.AddScoped<ITablaMaestraEventHandlers, TablaMaestraEventHandlers>();
            services.AddScoped<ITipoMuestraEventHandlers, TipoMuestraEventHandlers>();

            services.AddScoped<IAreaQueryService, AreaQueryService>();
            services.AddScoped<IEquipoMedicoExamenQueryService, EquipoMedicoExamenQueryService>();
            services.AddScoped<IEquipoMedicoQueryService, EquipoMedicoQueryService>();
            services.AddScoped<IExamenQueryService, ExamenQueryService>();
            services.AddScoped<IHospitalQueryService, HospitalQueryService>();
            services.AddScoped<ILaboratorioQueryService, LaboratorioQueryService>();
            services.AddScoped<IPersonaQueryService, PersonaQueryService>();
            services.AddScoped<ISistemaClienteExamenQueryService, SistemaClienteExamenQueryService>();
            services.AddScoped<ISistemaClienteQueryService, SistemaClienteQueryService>();
            services.AddScoped<ITablaMaestraQueryService, TablaMaestraQueryService>();
            services.AddScoped<ITipoMuestraQueryService, TipoMuestraQueryService>();
            services.AddScoped<IPerfilEventHandlers, PerfilEventHandlers>();
            services.AddScoped<IPerfilExamenEventHandlers, PerfilExamenEventHandlers>();
            services.AddScoped<IPerfilExamenQueryService, PerfilExamenQueryService>();
            services.AddScoped<IPerfilQueryService, PerfilQueryService>();

            services.AddScoped<ICurrentUserService, CurrentUserService>();

        }
    }
}
