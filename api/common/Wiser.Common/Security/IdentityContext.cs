using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Wiser.Common.Security
{
    public class IdentityContext : IIdentityContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Guid UserId { get; private set; } = default!;

        public Guid CompanyId { get; private set; } = default!;

        public IdentityContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            SetContext();
        }

        private void SetContext()
        {
            if (_httpContextAccessor.HttpContext != null &&
                _httpContextAccessor.HttpContext.User != null &&
                _httpContextAccessor.HttpContext.User.Claims != null)
            {
                Claim? userIdClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.UserId);

                if (userIdClaim != null)
                {
                    UserId = Guid.Parse(userIdClaim.Value);
                }

                Claim? companyIdClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.CompanyId);

                if (companyIdClaim != null)
                {
                    CompanyId = Guid.Parse(companyIdClaim.Value);
                }
            }
        }
    }
}
