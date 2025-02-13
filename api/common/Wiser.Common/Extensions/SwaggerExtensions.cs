using Wiser.Common.ConfigurationSections;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using NJsonSchema;
using NJsonSchema.Generation;
using NSwag;
using NSwag.Generation.Processors.Security;

namespace Wiser.Common.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddApiSwaggerDocument(this IServiceCollection services, IConfiguration configuration)
        {
            var swaggerOptions = configuration.GetSection<SwaggerOptions>();

            services.AddOpenApiDocument((config, services) =>
            {
                if (swaggerOptions != null)
                {
                    var jsonOptions = services.GetRequiredService<IOptions<JsonOptions>>();
                    config.SchemaSettings = new SystemTextJsonSchemaGeneratorSettings
                    {
                        SchemaType = SchemaType.OpenApi3,
                        SerializerOptions = jsonOptions.Value.SerializerOptions
                    };

                    config.DocumentName = "v1";
                    config.Title = swaggerOptions.Title;
                    config.Version = "v1";

                    config.AddSecurity(swaggerOptions.Scheme, Enumerable.Empty<string>(), new OpenApiSecurityScheme
                    {
                        Type = OpenApiSecuritySchemeType.ApiKey,
                        In = OpenApiSecurityApiKeyLocation.Header,
                        Name = HeaderNames.Authorization,
                        Scheme = JwtBearerDefaults.AuthenticationScheme,
                        BearerFormat = "JWT",
                        Description = "Copy 'Bearer ' + valid JWT token into field"
                    });

                    config.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor(swaggerOptions.Scheme));
                }
            });

            return services;
        }
    }
}
