using System.Collections.Generic;
using System.Linq;

using WEB_Basics_Project.Domain;
using WEB_Basics_Project.Service.Repositories;

namespace WEB_Basics_Project.Sql.Data.SQLServer.DataAccess
{
    public class VolunteerRepository : IVolunteerRepository
    {
        private readonly ApplicationDbContext _context;
        public VolunteerRepository(ApplicationDbContext context)
            => this._context = context;

        public int Create(Volunteer newVolunteer)
        {
            this._context.Volunteers.Add(newVolunteer);
            return this._context.SaveChanges();
        }

        public List<Volunteer> GetAll() => this._context.Volunteers.ToList();

        public List<Volunteer> GetUnion(Volunteer filter) => this._context.Volunteers.Where(v =>
            v.Id == filter.Id ||
            v.FirstName == filter.FirstName ||
            v.LastName == filter.LastName ||
            v.PhoneNumber == filter.PhoneNumber ||
            v.Email == filter.Email
        ).ToList();

        public List<Volunteer> GetIntersection(Volunteer filter) => this._context.Volunteers.Where(v =>
            (filter.Id == null || v.Id == filter.Id) &&
            (filter.FirstName == null || v.FirstName == filter.FirstName) &&
            (filter.LastName == null || v.LastName == filter.LastName) &&
            (filter.PhoneNumber == null || v.PhoneNumber == filter.PhoneNumber) &&
            (filter.Email == null || v.Email == filter.Email)
        ).ToList();

        public int Update(Volunteer target)
        {
            var volunteer = this._context.Volunteers.First(v => v.Id == target.Id);
            if (target.FirstName != null) volunteer.FirstName = target.FirstName;
            if (target.LastName != null) volunteer.LastName = target.LastName;
            if (target.PhoneNumber != null) volunteer.PhoneNumber = target.PhoneNumber;
            if (target.Email != null) volunteer.Email = target.Email;
            return this._context.SaveChanges();
        }

        public int Delete(string id)
        {
            this._context.Remove(this._context.Volunteers.First(v => v.Id == id));
            return this._context.SaveChanges();
        }
    }
}