using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using WEB_Basics_Project.Data.SQLServer.DataAccess;
using WEB_Basics_Project.Sql;

using WebAPI.Models.Settings;

namespace WEB_Basics_Project
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
            => this._configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDbSettings>(new DbSettings { ConnectionString = this._configuration.GetConnectionString("DefaultConnection") });
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