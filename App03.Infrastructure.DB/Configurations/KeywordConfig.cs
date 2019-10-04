using App01.Domain.Entities;
using App03.Infrastructure.DB.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App03.Infrastructure.DB.Configurations
{
    public class KeywordConfig : BaseEntityConfiguration<Keyword, int>
    {
        public override void Configure(EntityTypeBuilder<Keyword> builder)
        {
            builder.Property(c => c.Title).HasMaxLength(50).IsRequired();

            base.Configure(builder);
        }
    }
}