using Wiser.Identity.Domain.Entities;

namespace Wiser.Identity.Infrastructure.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
