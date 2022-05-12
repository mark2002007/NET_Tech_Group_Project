using System.Collections.Generic;
using System.Linq;
using WEB_Basics_Project.Sql.Data.SQLServer.Models;

namespace WEB_Basics_Project.Sql.Data.SQLServer.DataAccess
{
    public class ServiceRepository : IRepository<Service>
    {
        private ApplicationDbContext db { get; set; }
        public ServiceRepository()
        {
            db = new ApplicationDbContext();
        }

        public int Create(Service newService)
        {
            db.Services.Add(newService);
            return db.SaveChanges();
        }

        public List<Service> GetAll() => db.Services.ToList();

        public List<Service> GetUnion(Service filter) => db.Services.Where(s =>
            s.ServiceID == filter.ServiceID ||
            s.Volunteer.VolunteerID == filter.Volunteer.VolunteerID ||
            s.Description.Contains(filter.Description)
        ).ToList();

        public List<Service> GetIntersection(Service filter) => db.Services.Where(s =>
            s.ServiceID == filter.ServiceID &&
            s.Volunteer.VolunteerID == filter.Volunteer.VolunteerID &&
            s.Description.Contains(filter.Description)
        ).ToList();

        public int Update(Service target)
        {
            var service = db.Services.First(s => s.ServiceID == target.ServiceID);
            if (target.Volunteer != null) service.Volunteer = target.Volunteer;
            if (target.Description != null) service.Description = target.Description;
            return db.SaveChanges();
        }

        public int Delete(int id)
        {
            db.Remove(db.Services.First(s => s.ServiceID == id));
            return db.SaveChanges();
        }

    }
}


