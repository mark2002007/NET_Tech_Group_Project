using System.Collections.Generic;
using System.Linq;

using WEB_Basics_Project.Domain;
using WEB_Basics_Project.Service.Repositories;

namespace WEB_Basics_Project.Sql.Data.SQLServer.DataAccess
{
    public class HotlineRepository : IHotlineRepository
    {
        private readonly ApplicationDbContext _context;
        public HotlineRepository(ApplicationDbContext context)
            => this._context = context;

        
        /// <summary>
        /// Adds Hotline to Database
        /// </summary>
        /// <param name="newHotline">Hotline to add</param>
        /// <returns>Number of changes</returns>
        public int Create(Hotline newHotline)
        {
            this._context.Hotlines.Add(newHotline);
            return this._context.SaveChanges();
        }

        /// <summary>
        /// Gets all Hotlines
        /// </summary>
        /// <returns>All Hotlines in Database</returns>
        public List<Hotline> GetAll() => this._context.Hotlines.ToList();

        /// <summary>
        /// Gets Union of Hotlines
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns>All Hotlines that have one common property with filter</returns>
        public List<Hotline> GetUnion(Hotline filter) => this._context.Hotlines.Where(h =>
            h.Name == filter.Name ||
            h.Number == filter.Number
        ).ToList();

        /// <summary>
        /// Gets Intersection of Hotlines
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>All Hotlines that have all common properties with filter</returns>
        public List<Hotline> GetIntersection(Hotline filter) => this._context.Hotlines.Where(h =>
            h.Name == filter.Name &&
            h.Number == filter.Number
        ).ToList();

        /// <summary>
        /// Updates Hotline according to ID
        /// </summary>
        /// <param name="target"></param>
        /// <returns>Number of changes</returns>
        public int Update(Hotline target)
        {
            var hotline = this._context.Hotlines.First(h => h.HotlineID == target.HotlineID);
            if (target.Name != null) hotline.Name = target.Name;
            if (target.Number != null) hotline.Number = target.Number;
            return this._context.SaveChanges();
        }

        /// <summary>
        /// Deletes Hotline according to ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Number of changes</returns>
        public int Delete(int id)
        {
            this._context.Remove(this._context.Hotlines.First(h => h.HotlineID == id));
            return this._context.SaveChanges();
        }
    }
}