using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using System.Reflection;
using System.Security;
using Wiser.Identity.Domain.Entities;

namespace Wiser.Identity.Domain
{
    internal sealed class IdentityDbContext : DbContext, IIdentityDbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
        }
    }
}
