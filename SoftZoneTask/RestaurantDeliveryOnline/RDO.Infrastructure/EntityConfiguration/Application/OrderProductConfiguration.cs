using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RDO.Core.Entities;

namespace RDO.Infrastructure.EntityConfiguration
{
    public class OrderProductsConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.ToTable("OrderProducts", "RDO");
            
            builder.Property(m => m.Id)
                .ValueGeneratedNever();

            builder.HasOne(m => m.Product)
                .WithMany()
                .HasForeignKey(m => m.ProductId);
        }
    }
}
