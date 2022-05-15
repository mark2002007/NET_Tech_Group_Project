using Microsoft.EntityFrameworkCore;

using WEB_Basics_Project.Domain;

namespace WEB_Basics_Project.Sql.Data.SQLServer.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Hotline> Hotlines { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Domain.Service> Services { get; set; }

        public ApplicationDbContext() : base() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}