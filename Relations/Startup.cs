using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using RelationApp.Persistence.Contexts;
using RelationApp.Domain.Iterfaces;
using RelationApp.Domain.Models;
using RelationApp.Persistence.Repositories;
using RelationApp.Services;
using AutoMapper;

namespace RelationApp.Client
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            
            services.AddControllersWithViews();

            services.AddDbContext<RelationAppContext>(options => 
                options.UseSqlServer( Configuration.GetConnectionString("RelationsDb") ));
           
            services.AddScoped<IRepository<Relation>, RelationRepository>();

            services.AddScoped<IRelationService, RelationService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Relation}/{action=Index}/{sortfield?}");
            });
        }
    }
}
