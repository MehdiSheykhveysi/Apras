using App01.Domain.Entities;
using App03.Infrastructure.DB.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App03.Infrastructure.DB.Configurations
{
    public class CategoryConfig : BaseEntityConfiguration<Category, int>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Title).HasMaxLength(50);

            //Relations
            builder.HasOne(c => c.ParentCategory).WithMany(c => c.ChildCategories).HasForeignKey(c => c.ParentCategoryID).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            
            base.Configure(builder);
        }
    }
}
