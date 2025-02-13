using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wiser.Identity.Domain.Interfaces;
using Wiser.Identity.Domain.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Wiser.Identity.Domain
{
    public static class DataAccessServicesRegistration
    {
        private const string IdentityConnectionStringKey = "Identity";

        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(IdentityConnectionStringKey));
            });

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        public static void MigrateDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<IdentityDbContext>();
            context.Database.Migrate();
        }
    }
}
