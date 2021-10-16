using RDO.WebApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RDO.Infrastructure.DbContexts;
using Newtonsoft.Json;
using AutoMapper;

namespace RDO.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Access to the HttpContext inside a service.
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            //    AddDbContext ==> Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore -Version 3.1.3
            //    UseSqlServer ==> Install - Package Microsoft.EntityFrameworkCore.SqlServer - Version 3.1.3
            services.AddDbContext<CommandDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:Default"],
                    sqlOption =>
                    {
                        sqlOption.EnableRetryOnFailure();
                        sqlOption.MigrationsAssembly("RDO.Infrastructure");
                    });
            });

            //  Add AutoMapper ==> 
            //  Install - Package AutoMapper - Version 10.0.0
            //  Install - Package AutoMapper.Extensions.Microsoft.DependencyInjection - Version 8.0.1
            services.AddAutoMapper();


            services.AddLocalization();

            // Get the configrations from appsettings.json

            // Configure application services.
            services.AddServices();

            // Configure repositories.
            services.AddRepositories();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(option =>
            {
                option.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
            });

            // Put here (after UseRouting & before  UseEndpoints)

            app.UseEndpoints(endpoints =>
            {
                if (env.IsDevelopment())
                {
                    endpoints.MapGet("/show-config", async context =>
                    {
                        var configInfo = (Configuration as IConfigurationRoot).GetDebugView();
                        await context.Response.WriteAsync(configInfo);
                    });
                }

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}").RequireAuthorization();
            });

        }

    }
}
