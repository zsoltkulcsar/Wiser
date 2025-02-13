using Wiser.Common.Extensions.Attributes;

namespace Wiser.Common.ConfigurationSections
{
    [SectionName(SectionNames.Jwt)]
    public sealed record JwtOptions
    {
        public string Issuer { get; set; } = default!;

        public string Audience { get; set; } = default!;

        public string Key { get; set; } = default!;

        public int TokenExpiresInMinutes { get; set; }

        public int RefreshTokenExpiresInDays { get; set; }
    }
}
