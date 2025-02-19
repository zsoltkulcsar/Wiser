using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Wiser.Identity.CQRS.Handlers
{
    public static class CQRSServicesRegistration
    {
        public static IServiceCollection AddCQRSServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
