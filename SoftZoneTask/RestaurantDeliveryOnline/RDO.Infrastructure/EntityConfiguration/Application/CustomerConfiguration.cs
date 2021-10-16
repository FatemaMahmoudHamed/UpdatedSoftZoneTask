using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RDO.Core.Entities;

namespace RDO.Infrastructure.EntityConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers", "RDO");

            builder.Property(m => m.Id)
              .ValueGeneratedNever();

        }
    }
}
