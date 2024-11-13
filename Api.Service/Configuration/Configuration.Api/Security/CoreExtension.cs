namespace Configuration.Api.Security
{
    public static class CoreExtension
    {
        public static IServiceCollection AddCorsApp(this IServiceCollection services)
        {
            return
            services.AddCors(o => o.AddPolicy("corsApp", builder =>
            {
                builder
                        .AllowAnyHeader()
                         .AllowAnyMethod().
                         SetIsOriginAllowed(origin => true)
                         .AllowCredentials();
            }));

        }
        public static IApplicationBuilder UserCoreApp(this IApplicationBuilder app)
        {
            return app.UseCors("corsApp");


        }
    }
}
