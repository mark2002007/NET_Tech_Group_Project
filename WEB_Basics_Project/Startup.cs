using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using WEB_Basics_Project.Service.Repositories;
using WEB_Basics_Project.Service.Services;
using WEB_Basics_Project.Sql.Data.SQLServer.DataAccess;

namespace WEB_Basics_Project
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
            => this._configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(this._configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<IHotlineRepository, HotlineRepository>();
            services.AddScoped<IVolunteerRepository, VolunteerRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();

            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<IHotlineService, HotlineService>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}