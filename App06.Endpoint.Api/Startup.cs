using System;
using App01.Domain.Entities;
using App03.Infrastructure.DB.Context;
using App05.Bootstraper.Extensions;
using App05.Bootstraper.Mapping;
using Apras04.ApplicationService.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App06.Endpoint.Api
{
    public partial class Startup
    {
        private IConfiguration _configuration { get; set; }
        private readonly SiteSettingService _siteSettingService;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            _siteSettingService = configuration.GetSection("SiteSettings").Get<SiteSettingService>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityService<AppUser, Guid, AprasContext>();
            services.Configure<SiteSettingService>(_configuration.GetSection("SiteSettings"));

            services.AddDbContextPool<AprasContext>(options =>
            {
                options.UseSqlServer(_siteSettingService.DefaultConnection);
                //Disable Client Site Evaluation 
                options.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
            });
            services.AddControlers();
            services.AddScopedDependencies(typeof(AprasContext).Assembly);
            services.Configure<AutoMapperConfiguration>(_configuration);
        }
    }

    public partial class Startup
    {
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
