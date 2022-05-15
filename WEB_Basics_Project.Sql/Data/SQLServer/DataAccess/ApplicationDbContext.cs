using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WEB_Basics_Project.Sql.Data.SQLServer.Models;

namespace WEB_Basics_Project.Sql.Data.SQLServer.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Hotline> Hotlines { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Service> Services { get; set; }
        

        public ApplicationDbContext() : base()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-9GGT2EU;Initial Catalog=NET_Tech_Group_Project_DB;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //
            //=====One to Many Relationships=====
            //

            modelBuilder.Entity<Volunteer>()
                .HasMany(v => v.Services)
                .WithOne(s => s.Volunteer);

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
                .Property(v => v.PhoneNumber)
                .HasMaxLength(16);

            modelBuilder.Entity<Volunteer>()
                .Property(v => v.Email)
                .HasMaxLength(64);


            //
            //=====Service=====
            //

            modelBuilder.Entity<Service>()
                .Property(s => s.ServiceID)
                .IsRequired();

            modelBuilder.Entity<Service>()
                .Property(s => s.ServiceID)
                .IsRequired();

            modelBuilder.Entity<Service>()
                .Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(2024);

            //
            //=====Hotline=====
            //

            modelBuilder.Entity<Hotline>()
                .Property(h => h.HotlineID)
                .IsRequired();

            modelBuilder.Entity<Hotline>()
                .Property(h => h.Name)
                .IsRequired()
                .HasMaxLength(256);

            modelBuilder.Entity<Hotline>()
                .Property(h => h.Number)
                .IsRequired()
                .HasMaxLength(16);

            modelBuilder.Entity<Hotline>()
                .Property(h => h.Area)
                .IsRequired()
                .HasMaxLength(256);

            //
            //=====Area=====
            //

            modelBuilder.Entity<Area>()
                .Property(a => a.AreaID)
                .IsRequired();

            modelBuilder.Entity<Area>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(256);
        }

        public bool Populate()
        {
            try
            {
                //=====Volunteers=====
                var db = new ApplicationDbContext();
                db.Volunteers.Add(new Volunteer
                {
                    FirstName = "Юлія",
                    LastName = "Жорняк",
                    PhoneNumber = "+380000000000",
                    Email = "#####@gmail.com"
                });
                db.Volunteers.Add(new Volunteer
                {
                    FirstName = "Марія",
                    LastName = "Гартованець",
                    PhoneNumber = "+380000000000",
                    Email = "#####@gmail.com"
                });
                db.Volunteers.Add(new Volunteer
                {
                    FirstName = "Станіслав",
                    LastName = "Тимняк",
                    PhoneNumber = "+380000000000",
                    Email = "#####@gmail.com"
                });
                db.Volunteers.Add(new Volunteer
                {
                    FirstName = "Маркіян",
                    LastName = "Щупляк",
                    PhoneNumber = "+380000000000",
                    Email = "#####@gmail.com"
                });
                db.Volunteers.Add(new Volunteer
                {
                    FirstName = "Маркіян",
                    LastName = "Щупляк",
                    PhoneNumber = "+380000000000",
                    Email = "#####@gmail.com"
                });
                db.Volunteers.Add(new Volunteer
                {
                    FirstName = "Маркіян",
                    LastName = "Мандзак",
                    PhoneNumber = "+380000000000",
                    Email = "#####@gmail.com"
                });
                db.Volunteers.Add(new Volunteer
                {
                    FirstName = "Юрій",
                    LastName = "Спасник",
                    PhoneNumber = "+380000000000",
                    Email = "#####@gmail.com"
                });
                //=====Services=====
                //TODO : Services Population

                //=====Hotlines=====
                //db.Hotlines.Add(new Hotline
                //{
                //    Name = "ЛКП \"Житловик - С\"",
                //    Number = "+38(032)254-66-56",
                //    Area = "Сихівський район"
                //});
                //db.Hotlines.Add(new Hotline
                //{
                //    Name = "ЛКП \"Хуторівка\"",
                //    Number = "+38(032)254-66-55",
                //    Area = "Сихівський район"
                //});
                //db.Hotlines.Add(new Hotline
                //{
                //    Name = "ЛКП \"Під Зуброю\"",
                //    Number = "+38(032)254-66-59",
                //    Area = "Сихівський район"
                //});
                //db.Hotlines.Add(new Hotline
                //{
                //    Name = "ЛКП \"Магістральне\"",
                //    Number = "+38(032)254-66-72",
                //    Area = "Франківський район"
                //});
                //db.Hotlines.Add(new Hotline
                //{
                //    Name = "ЛКП \"Вулецьке\"",
                //    Number = "+38(032)254-66-69",
                //    Area = "Франківський район"
                //});
                //db.Hotlines.Add(new Hotline
                //{
                //    Name = "ЛКП \"Аварійна служба Франківського\"",
                //    Number = "+38(032)263-25-61",
                //    Area = "Франківський район"
                //});
                //db.Hotlines.Add(new Hotline
                //{
                //    Name = "ЛКП \"Лівівський ліхтар\"",
                //    Number = "+38(032)254-66-68",
                //    Area = "Франківський район"
                //});
                //db.Hotlines.Add(new Hotline
                //{
                //    Name = "ЛКП \"Південне\"",
                //    Number = "+38(032)254-66-73",
                //    Area = "Франківський район"
                //});
                //db.Hotlines.Add(new Hotline
                //{
                //    Name = "ЛКП \"Айсберг\"",
                //    Number = "+38(032)254-66-43",
                //    Area = "Галицький район"
                //});
                //db.Hotlines.Add(new Hotline
                //{
                //    Name = "ЛКП \"Старий Львів\"",
                //    Number = "+38(032)254-66-40",
                //    Area = "Галицький район"
                //});
                //db.Hotlines.Add(new Hotline
                //{
                //    Name = "ЛКП \"Левандівка\"",
                //    Number = "+38(032)254-66-64",
                //    Area = "Залізничний район"
                //});
                //db.Hotlines.Add(new Hotline
                //{
                //    Name = "ЛКП \"Сигнівка\"",
                //    Number = "+38(032)254-66-65",
                //    Area = "Залізничний район"
                //});
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Depopulate()
        {
            try
            {
                var db = new ApplicationDbContext();
                db.Database.ExecuteSqlCommand("DELETE FROM Services");
                db.Database.ExecuteSqlCommand("DELETE FROM Volunteers");
                db.Database.ExecuteSqlCommand("DELETE FROM Hotlines");
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
