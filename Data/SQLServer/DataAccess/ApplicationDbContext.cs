using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WEB_Basics_Project.Data.SQLServer.Models;

namespace WEB_Basics_Project.Data.SQLServer.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        DbSet<Volunteer> Volunteers { get; set; }
        DbSet<Hotline> Hotlines{ get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //
            //=====Volunteer=====
            //

            modelBuilder.Entity<Volunteer>()
                .Property(v => v.VolunteerID)
                .IsRequired();

            modelBuilder.Entity<Volunteer>()
                .Property(v => v.FirstName)
                .IsRequired()
                .HasMaxLength(32);

            modelBuilder.Entity<Volunteer>()
                .Property(v => v.LastName)
                .IsRequired()
                .HasMaxLength(32);

            modelBuilder.Entity<Volunteer>()
                .Property(v => v.Age)
                .IsRequired();

            //
            //=====Hotline=====
            //

            modelBuilder.Entity<Hotline>()
                .Property(h => h.HotlineID)
                .IsRequired();

            modelBuilder.Entity<Hotline>()
                .Property(h => h.Name)
                .IsRequired();

            modelBuilder.Entity<Hotline>()
                .Property(h => h.Number)
                .IsRequired()
                .HasMaxLength(16);

            modelBuilder.Entity<Hotline>()
                .Property(h => h.Area)
                .IsRequired();

            modelBuilder.Entity<Hotline>()
                .Property(h => h.Operator)
                .IsRequired()
                .HasMaxLength(128);
        }
    }
}
