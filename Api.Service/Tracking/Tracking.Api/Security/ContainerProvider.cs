using Persistence.Database.CurrentUser.Service;
using Tracking.Service.Queries;

namespace Tracking.Api.Security
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
            services.AddScoped<ITrackingQueryService, TrackingQueryService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
        }
    }
}
