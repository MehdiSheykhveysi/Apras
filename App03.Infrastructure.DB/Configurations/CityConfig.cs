using App01.Domain.Entities;
using App03.Infrastructure.DB.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App03.Infrastructure.DB.Configurations
{
    public class CityConfig : BaseEntityConfiguration<City, int>
    {
        public override void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(50).IsRequired();

            base.Configure(builder);
        }
    }
}