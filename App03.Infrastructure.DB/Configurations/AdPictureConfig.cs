using App01.Domain.Entities;
using App03.Infrastructure.DB.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App03.Infrastructure.DB.Configurations
{
    public class AdPictureConfig : BaseEntityConfiguration<AdPicture, int>
    {
        public override void Configure(EntityTypeBuilder<AdPicture> builder)
        {
            builder.Property(c => c.ImagePath).HasMaxLength(250).IsRequired();

            base.Configure(builder);
        }
    }
}
