using Microsoft.AspNetCore.Identity;
using Wiser.Common.Entities;

namespace Wiser.Identity.Domain.Entities
{
    public sealed class User : TrackableEntity<Guid>
    {
        public string Name { get; set; } = default!;

        public string Email { get; set; } = default!;
       
        public string Password { get; set; } = default!;

        public string? Phone { get; set; }

        public string? Imaget { get; set; }

        public string? ExternalIdentifier { get; set; }
    }
}
