using Microsoft.AspNetCore.Identity;
using Wiser.Common.Repositories;
using Wiser.Identity.Domain.Entities;

namespace Wiser.Identity.Repositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
    }
}
