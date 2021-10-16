using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RDO.Core.Entities;

namespace RDO.Infrastructure.EntityConfiguration
{
    public abstract class BaseEntityConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity<TKey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.CreatedOn)
                .HasComment("The creation datetime")
                .IsRequired();

            builder.Property(m => m.IsDeleted)
                .HasComment("restaurant for the logical delete")
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasQueryFilter(m => !m.IsDeleted);
        }
    }
}
