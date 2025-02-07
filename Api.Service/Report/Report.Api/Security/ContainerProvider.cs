﻿using Persistence.Database.CurrentUser.Service;
using Report.Service.Queries;


namespace Report.Api.Security
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
            services.AddScoped<IEtiquetaQueryService, EtiquetaQueryService>();
            services.AddScoped<IReporteGraficoQueryService, ReporteGraficoQueryService>();
            services.AddScoped<IReporteResultadoQueryService, ReporteResultadoQueryService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
        }
    }
}
