namespace Tracking.Api.Security
{
    public static class CoreExtrension
    {
        public static IServiceCollection AddCorsApp(this IServiceCollection services)
        {
            return
                services.AddCors(x => x.AddPolicy("corsApp", builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(origen => true).AllowCredentials();
                }));
        }
        public static IApplicationBuilder UserCoreApp(this IApplicationBuilder app)
        {
            return app.UseCors("corsApp");
        }
    }
}
