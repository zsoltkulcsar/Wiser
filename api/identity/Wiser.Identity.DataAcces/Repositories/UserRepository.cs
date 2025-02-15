using Microsoft.EntityFrameworkCore;
using Wiser.Common.Repositories;
using Wiser.Identity.DataAcces;
using Wiser.Identity.Domain.Entities;
using Wiser.Identity.Repositories;

namespace Wiser.Identity.DataAccess
{
    internal sealed class UserRepository : BaseRepository<User, Guid>, IUserRepository
    {

        public UserRepository(IdentityDbContext context) : base(context)
        {
        }

        public async Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
            => await _context.Set<User>()
                .Where(u => u.Email == email)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);
    }
}