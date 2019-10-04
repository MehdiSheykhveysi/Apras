using App00.Common.Attributes;
using App05.Bootstraper.Filtes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System;
using System.Linq;
using System.Reflection;

namespace App05.Bootstraper.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddIdentityService<TUser, TKey, TContext>(this IServiceCollection services) where TUser : IdentityUser<TKey> where TContext : DbContext where TKey : IEquatable<TKey>
        {
            services.AddIdentityCore<TUser>(setupAction =>
            {
            }).AddEntityFrameworkStores<TContext>();
        }

        public static void AddScopedDependencies(this IServiceCollection services, Assembly targetAssembly)
        {
            services.Scan(scan => scan
              .FromAssemblies(targetAssembly)
                .AddClasses(classes => classes.WithAttribute(typeof(ServiceMark)))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                        .AsImplementedInterfaces()
                            .WithScopedLifetime());
        }

        public static void AddControlers(this IServiceCollection services)
        {
            services.AddMvcCore(option =>
            {
                option.Filters.Add(typeof(GlobalMvcValidateModelStateAttribute));

            }).AddJsonFormatters().AddApiExplorer().AddFormatterMappings().AddDataAnnotations().AddJsonFormatters().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddCookieTempDataProvider();
        }
    }
}