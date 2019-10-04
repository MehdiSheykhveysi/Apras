using App01.Domain.Entities;
using App03.Infrastructure.DB.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App03.Infrastructure.DB.Configurations
{
    public class ProvinceConfig : BaseEntityConfiguration<Province, int>
    {
        public override void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(50);

            base.Configure(builder);
        }
    }
}