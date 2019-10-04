using App01.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App03.Infrastructure.DB.Common
{
    public class BaseEntityConfiguration<TClass, Tkey> : IEntityTypeConfiguration<TClass> where TClass : BaseEntity<Tkey>
    {
        public virtual void Configure(EntityTypeBuilder<TClass> builder)
        {
            builder.HasKey(c => c.ID);
        }
    }
}