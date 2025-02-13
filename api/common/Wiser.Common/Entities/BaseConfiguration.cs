using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Wiser.Common.Entities
{
    public abstract class BaseConfiguration<T>
            : IEntityTypeConfiguration<T>
                where T : class
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            ConfigureEntity(builder);
            Seed(builder);
        }

        protected virtual void ConfigureEntity(EntityTypeBuilder<T> builder)
        {
        }

        protected virtual void Seed(EntityTypeBuilder<T> builder)
        {
        }
    }
}
