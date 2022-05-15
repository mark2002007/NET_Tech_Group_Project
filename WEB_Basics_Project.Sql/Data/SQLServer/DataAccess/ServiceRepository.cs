using System.Collections.Generic;
using System.Linq;

using WEB_Basics_Project.Service.Repositories;

namespace WEB_Basics_Project.Sql.Data.SQLServer.DataAccess
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _context;
        public ServiceRepository(ApplicationDbContext context)
            => this._context = context;

        public int Create(Domain.Service newService)
        {
            this._context.Services.Add(newService);
            return this._context.SaveChanges();
        }

        public List<Domain.Service> GetAll() => this._context.Services.ToList();

        public List<Domain.Service> GetUnion(Domain.Service filter) => this._context.Services.Where(s =>
            s.ServiceID == filter.ServiceID ||
            s.Volunteer.VolunteerID == filter.Volunteer.VolunteerID ||
            s.Description.Contains(filter.Description)
        ).ToList();

        public List<Domain.Service> GetIntersection(Domain.Service filter) => this._context.Services.Where(s =>
            s.ServiceID == filter.ServiceID &&
            s.Volunteer.VolunteerID == filter.Volunteer.VolunteerID &&
            s.Description.Contains(filter.Description)
        ).ToList();

        public int Update(Domain.Service target)
        {
            var service = this._context.Services.First(s => s.ServiceID == target.ServiceID);
            if (target.Volunteer != null) service.Volunteer = target.Volunteer;
            if (target.Description != null) service.Description = target.Description;
            return this._context.SaveChanges();
        }

        public int Delete(int id)
        {
            this._context.Remove(this._context.Services.First(s => s.ServiceID == id));
            return this._context.SaveChanges();
        }

    }
}