using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pluralize.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace App03.Infrastructure.DB.Utilities
{
    public static class ModelBuilderExtension
    {
        public static void AutoAddDbSetClass<BaseType>(this ModelBuilder modelBuilder, params Assembly[] assemblies)
        {
            IEnumerable<Type> types = assemblies.SelectMany(a => a.GetExportedTypes())
               .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic && typeof(BaseType).IsAssignableFrom(c));

            foreach (Type type in types)
                modelBuilder.Entity(type);
        }

        public static void AddPluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            Pluralizer pluralizer = new Pluralizer();
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                string tableName = entityType.Relational().TableName;
                entityType.Relational().TableName = pluralizer.Pluralize(tableName);
            }
        }

        public static void SetUpSequentialGuid(this ModelBuilder modelBuilder)
        {
            var property = modelBuilder.Model.GetEntityTypes()
                            .SelectMany(t => t.GetProperties())
                            .Where(p => p.ClrType == typeof(Guid) && p.IsKey());

            foreach (var p in property)
            {
                p.Relational().DefaultValueSql = "newsequentialid()";
            }
        }
    }
}
