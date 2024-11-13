using Persistence.Database.CurrentUser.Service;
using QualityControl.Service.EventHandlers;
using QualityControl.Service.Queries;

namespace QualityControl.Api
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

            services.AddScoped<ILoteQueryService, LoteQueryService>();
            services.AddScoped<ILoteEventHandlers, LoteEventHandlers>();

            services.AddScoped<INivelQueryService, NivelQueryService>();
            services.AddScoped<INivelEventHandlers, NivelEventHandlers>();

            services.AddScoped<IReactivoDetQueryService, ReactivoDetQueryService>();
            services.AddScoped<IReactivoDetEventHandlers, ReactivoDetEventHandlers>();


            services.AddScoped<IReactivoQueryService, ReactivoQueryService>();
            services.AddScoped<IReactivoEventHandlers, ReactivoEventHandlers>();

            services.AddScoped<IQCRangoQueryService, QCRangoQueryService>();
            services.AddScoped<IQCRangoEventHandlers, QCRangoEventHandlers>();

            services.AddScoped<IQCResultadoQueryService, QCResultadoQueryService>();
            services.AddScoped<IQCResultadoEventHandlers, QCResultadoEventHandlers>();

            services.AddScoped<ICurrentUserService, CurrentUserService>();

        }
    }
}
