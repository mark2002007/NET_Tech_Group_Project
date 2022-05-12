using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WEB_Basics_Project.Sql.Data.SQLServer.Models;

namespace WEB_Basics_Project.Sql.Data.SQLServer.DataAccess
{
    public class VounteerRepository : IRepository<Volunteer>
    {
        private ApplicationDbContext db { get; set; }
        public VounteerRepository()
        {
            db = new ApplicationDbContext();
        }
        public int Create(Volunteer newVolunteer)
        {
            db.Volunteers.Add(newVolunteer);
            return db.SaveChanges();
        }

        public List<Volunteer> GetAll() => db.Volunteers.ToList();

        public List<Volunteer> GetUnion(Volunteer filter) => db.Volunteers.Where(v =>
            v.VolunteerID == filter.VolunteerID ||
            v.FirstName == filter.FirstName ||
            v.LastName == filter.LastName ||
            v.PhoneNumber == filter.PhoneNumber ||
            v.Email == filter.Email
        ).ToList();

        public List<Volunteer> GetIntersection(Volunteer filter) => db.Volunteers.Where(v =>
            (filter.VolunteerID == null || v.VolunteerID == filter.VolunteerID) &&
            (filter.FirstName == null || v.FirstName == filter.FirstName) &&
            (filter.LastName == null || v.LastName == filter.LastName) &&
            (filter.PhoneNumber == null || v.PhoneNumber == filter.PhoneNumber) &&
            (filter.Email == null || v.Email == filter.Email)
        ).ToList();

        public int Update(Volunteer target)
        {
            var volunteer = db.Volunteers.First(v => v.VolunteerID == target.VolunteerID);
            if (target.FirstName != null) volunteer.FirstName = target.FirstName;
            if (target.LastName != null) volunteer.LastName = target.LastName;
            if (target.PhoneNumber != null) volunteer.PhoneNumber = target.PhoneNumber;
            if (target.Email != null) volunteer.Email = target.Email;
            return db.SaveChanges();
        }

        public int Delete(int id)
        {
            db.Remove(db.Volunteers.First(v => v.VolunteerID == id));
            return db.SaveChanges();
        }
    }
}


