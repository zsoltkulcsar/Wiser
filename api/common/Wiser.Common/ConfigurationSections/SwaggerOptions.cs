using Wiser.Common.Extensions.Attributes;

namespace Wiser.Common.ConfigurationSections
{
    [SectionName(SectionNames.Swagger)]
    public sealed record SwaggerOptions
    {
        public string Scheme { get; set; } = default!;

        public string Title { get; set; } = default!;
    }
}
