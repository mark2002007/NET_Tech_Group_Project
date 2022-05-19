using System.Collections.Generic;
using System.Linq;

using WEB_Basics_Project.Service.Repositories;

using WEB_Basics_Project.Domain;

namespace WEB_Basics_Project.Sql.Data.SQLServer.DataAccess
{
    /// <summary>
    /// Represents Areas Repository
    /// </summary>
    public class AreaRepository : IAreaRepository
    {
        private readonly ApplicationDbContext _context;
        public AreaRepository(ApplicationDbContext context)
            => this._context = context;

        /// <summary>
        /// Adds Area to database
        /// </summary>
        /// <param name="newArea">Area to add</param>
        /// <returns>Number of changes</returns>
        public int Create(Area newArea)
        {
            this._context.Areas.Add(newArea);
            return this._context.SaveChanges();
        }

        /// <summary>
        /// Gets all Areas
        /// </summary>
        /// <returns>All Areas in Database</returns>
        public List<Area> GetAll() => this._context.Areas.ToList();

        /// <summary>
        /// Gets Union of Areas
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns>All Areas that have one common property with filter</returns>
        public List<Area> GetUnion(Area filter) => this._context.Areas.Where(a =>
            a.AreaID == filter.AreaID ||
            a.Name == filter.Name
        ).ToList();

        /// <summary>
        /// Gets Intersection of Areas
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns>All Areas that have all common properties with filter</returns>
        public List<Area> GetIntersection(Area filter) => this._context.Areas.Where(a =>
            a.AreaID == filter.AreaID &&
            a.Name == filter.Name
        ).ToList();

        /// <summary>
        /// Updates Area according to target ID
        /// </summary>
        /// <param name="target"></param>
        /// <returns>Number of changes</returns>
        public int Update(Area target)
        {
            var area = this._context.Areas.First(a => a.AreaID == target.AreaID);
            if (target.Name != null) area.Name = target.Name;
            return this._context.SaveChanges();
        }

        /// <summary>
        /// Deletes Area according to targer ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Number of changes</returns>
        public int Delete(int id)
        {
            this._context.Remove(this._context.Areas.First(a => a.AreaID == id));
            return this._context.SaveChanges();
        }
    }
}