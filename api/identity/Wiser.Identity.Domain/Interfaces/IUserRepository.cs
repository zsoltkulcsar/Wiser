using Microsoft.AspNetCore.Identity;
using Wiser.Common.Repositories;
using Wiser.Identity.Domain.Entities;

namespace Wiser.Identity.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        Task<User> GetByEmailAsync(string email);
        Task<IdentityResult> CreateUserAsync(User user, string password);
        Task<bool> CheckPasswordAsync(User user, string password);
    }
}
