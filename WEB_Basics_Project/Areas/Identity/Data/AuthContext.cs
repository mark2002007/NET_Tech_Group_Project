using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using WEB_Basics_Project.Domain;

namespace WEB_Basics_Project.Data
{
    public class AuthContext : IdentityDbContext<Volunteer>
    {
        public AuthContext(DbContextOptions<AuthContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
            => base.OnModelCreating(builder);
    }
}