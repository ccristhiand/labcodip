using Persistence.Database.CurrentUser.Service;

namespace Api.Gateways.Security
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

            services.AddScoped<ICurrentUserService, CurrentUserService>();
        }
    }
}
