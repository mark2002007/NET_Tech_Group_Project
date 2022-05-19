using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using WEB_Basics_Project.Data;
using WEB_Basics_Project.Domain;
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
            /* services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(this._configuration.GetConnectionString("DefaultConnection")));
             services.AddDbContext<AuthContext>(options => options.UseSqlServer(this._configuration.GetConnectionString("DefaultConnection")));*/

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Server=tcp:help-during-the-war.database.windows.net,1433;Initial Catalog=HelpDuringTheWarDB;Persist Security Info=False;User ID=HelpDuring;Password=QWErty!@#456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
            services.AddDbContext<AuthContext>(options => options.UseSqlServer("Server=tcp:help-during-the-war.database.windows.net,1433;Initial Catalog=HelpDuringTheWarDB;Persist Security Info=False;User ID=HelpDuring;Password=QWErty!@#456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));

            services.AddDefaultIdentity<Volunteer>(options =>
                {
                    options.Password.RequiredLength = 8;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.SignIn.RequireConfirmedAccount = false;
                })
                .AddEntityFrameworkStores<AuthContext>();

            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<IHotlineRepository, HotlineRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();

            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<IHotlineService, HotlineService>();
            services.AddScoped<IServicesService, ServicesService>();

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