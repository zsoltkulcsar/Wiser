using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using System.Reflection;
using System.Security;
using Wiser.Identity.Domain.Entities;

namespace Wiser.Identity.Domain
{
    public interface IIdentityDbContext
    {
        DbSet<User> Users { get; set; }
    }
}
