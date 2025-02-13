using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Wiser.Common.ConfigurationSections;
using Wiser.Common.Security;

namespace Wiser.Common.Extensions
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddApiAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtOptions = configuration.GetSection<JwtOptions>();

            services.AddHttpContextAccessor();

            services.AddScoped<IIdentityContext, IdentityContext>();

            services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    if (jwtOptions != null)
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidIssuer = jwtOptions.Issuer,
                            ValidAudience = jwtOptions.Audience,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key))
                        };
                    }
                });

            return services;
        }
    }
}
