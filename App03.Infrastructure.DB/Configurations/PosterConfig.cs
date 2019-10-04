using App01.Domain.Entities;
using App03.Infrastructure.DB.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace App03.Infrastructure.DB.Configurations
{
    class PosterConfig : BaseEntityConfiguration<Poster, Guid>
    {
        public override void Configure(EntityTypeBuilder<Poster> builder)
        {
            builder.Property(c => c.Title).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(250);
            builder.Property(c => c.PhoneNumber).HasMaxLength(11);
            builder.Property(c => c.Email).HasMaxLength(50);
            builder.Property(c => c.WebSiteAddress).HasMaxLength(100);

            //Relations
            builder.HasOne(c => c.Province).WithMany(c => c.Posters).HasForeignKey(c => c.ProvinceId);
            builder.HasMany(c => c.AdPictures).WithOne(c => c.Poster).HasForeignKey(c => c.PosterID);
            builder.HasOne(c => c.Category).WithMany(c => c.Posters).HasForeignKey(c => c.CategoryID);
            builder.HasMany(c => c.KeyWords).WithOne(c => c.Poster).HasForeignKey(c => c.PosterID);

            base.Configure(builder);
        }
    }
}