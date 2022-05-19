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

        /// <summary>
        /// Adds Service to Database
        /// </summary>
        /// <param name="newService">Serive to add</param>
        /// <returns>Number of changes</returns>
        public int Create(Domain.Service newService)
        {
            this._context.Services.Add(newService);
            return this._context.SaveChanges();
        }

        /// <summary>
        /// Gets all Services
        /// </summary>
        /// <returns>All Services in Database</returns>
        public List<Domain.Service> GetAll() => this._context.Services.ToList();

        /// <summary>
        /// Gets Union of Services
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns>All Serives that have one common property with filter</returns>
        public List<Domain.Service> GetUnion(Domain.Service filter) => this._context.Services.Where(s =>
            s.ServiceID == filter.ServiceID ||
            s.VolunteerID == filter.VolunteerID ||
            s.Description.Contains(filter.Description)
        ).ToList();

        /// <summary>
        /// Gets Intersection of Services
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>All Services that have all common properties with filter</returns>
        public List<Domain.Service> GetIntersection(Domain.Service filter) => this._context.Services.Where(s =>
            s.ServiceID == filter.ServiceID &&
            s.VolunteerID == filter.VolunteerID &&
            s.Description.Contains(filter.Description)
        ).ToList();

        /// <summary>
        /// Updates Service according to ID
        /// </summary>
        /// <param name="target"></param>
        /// <returns>Number of changes</returns>
        public int Update(Domain.Service target)
        {
            var service = this._context.Services.First(s => s.ServiceID == target.ServiceID);
            if (target.VolunteerID != null) service.VolunteerID = target.VolunteerID;
            if (target.Description != null) service.Description = target.Description;
            return this._context.SaveChanges();
        }

        /// <summary>
        /// Deletes Service according to ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Number of changes</returns>
        public int Delete(int id)
        {
            this._context.Remove(this._context.Services.First(s => s.ServiceID == id));
            return this._context.SaveChanges();
        }

    }
}