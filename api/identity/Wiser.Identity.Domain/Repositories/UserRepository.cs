using Microsoft.AspNetCore.Identity;
using Wiser.Common.Repositories;
using Wiser.Identity.Domain.Entities;
using Wiser.Identity.Domain.Interfaces;

namespace Wiser.Identity.Domain.Repositories
{
    internal sealed class UserRepository : BaseRepository<User, Guid>, IUserRepository
    {

        private readonly UserManager<User> _userManager;

        public UserRepository(IdentityDbContext context, UserManager<User> userManager) : base(context) 
        {
            _userManager = userManager;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IdentityResult> CreateUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }
    }

}
