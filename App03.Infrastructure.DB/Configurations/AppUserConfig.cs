using App01.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App03.Infrastructure.DB.Configurations
{
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasDefaultValueSql("newsequentialid()"); //Use Sequential Guid In SqlServer For Generate Key


            //Relations
            builder.HasMany(c => c.Posters).WithOne(c => c.AppUser).HasForeignKey(c => c.AppUserId);
        }
    }
}
