using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using school_register.Data;
using school_register.Services;
using System;
using school_register.Services.Extension;

namespace school_register
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // DbContext services

            services.AddDbContext<SchoolRegisterDbContext>(options =>
                    options.UseMySql(Environment.GetEnvironmentVariable("MYSQLCONNSTR_localdb").ConnectionStringMySQL()));

            // HTTP request services services
            services.AddScoped<ISchoolRegisterRepository, SchoolRegisterRepository>();
            services.AddScoped<IViewModelMap, ViewModelMap>();
            services.AddTransient<SchoolRegisterDbContextSeeding>();

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, SchoolRegisterDbContextSeeding seeder)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            seeder.EnsureSeedData().Wait();

            app.UseMvc(configureRoutes);
        }

        private void configureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default",
                    "{controller=Class}/{action=Index}/{id?}");
        }
    }
}
