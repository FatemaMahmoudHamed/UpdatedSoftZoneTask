using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RDO.Core.Entities;

namespace RDO.Infrastructure.EntityConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "RDO");

            builder.Property(m => m.Id)
               .ValueGeneratedNever();

            builder.HasOne(m => m.Customer)
                .WithMany()
                .HasForeignKey(m => m.CustomerId);
        }
    }
}
