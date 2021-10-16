using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RDO.Core.Entities;

namespace RDO.Infrastructure.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "RDO");

            builder.Property(m => m.Id)
               .ValueGeneratedNever();
        }
    }
}
