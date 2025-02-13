using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Wiser.Common.Extensions
{
    public static class CorsExtensions
    {
        private const string CorsPolicy = "CorsPolicy";
        private const string CorsOriginsKey = "CorsOrigins";

        public static IServiceCollection AddApiCors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicy,
                    policy =>
                    {
                        policy.WithOrigins(configuration.GetSection(CorsOriginsKey).Get<string[]>() ?? Array.Empty<string>())
                        .AllowCredentials()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            return services;
        }

        public static WebApplication UseApiCors(this WebApplication app)
        {
            app.UseCors(CorsPolicy);

            return app;
        }
    }
}
