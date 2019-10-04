using App01.Domain.Entities;
using App01.Domain.Entities.Common;
using App03.Infrastructure.DB.Utilities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace App03.Infrastructure.DB.Context
{
    public class AprasContext : IdentityDbContext<AppUser,Role,Guid>
    {
        public AprasContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.AutoAddDbSetClass<IEntity>(this.GetType().Assembly);
            builder.AddPluralizingTableNameConvention();
            builder.ForSqlServerUseSequenceHiLo("DBSequenceHiLo");
            builder.SetUpSequentialGuid();
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            
        }
    }
}
