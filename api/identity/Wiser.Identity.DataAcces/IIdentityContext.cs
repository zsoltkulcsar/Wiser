using Microsoft.EntityFrameworkCore;
using Wiser.Identity.Domain.Entities;

namespace Wiser.Identity.DataAccess
{
    public interface IIdentityDbContext
    {
        DbSet<User> Users { get; set; }
    }
}
