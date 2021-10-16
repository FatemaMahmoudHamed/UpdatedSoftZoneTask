using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RDO.Core.Entities;

namespace RDO.Infrastructure.EntityConfiguration
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.ToTable("Restaurants", "RDO");

            builder.Property(m => m.Id)
               .ValueGeneratedNever();
        }
    }
}
