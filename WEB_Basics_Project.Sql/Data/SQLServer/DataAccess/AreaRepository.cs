using System.Collections.Generic;
using System.Linq;

using WEB_Basics_Project.Service.Repositories;

using WEB_Basics_Project.Domain;

namespace WEB_Basics_Project.Sql.Data.SQLServer.DataAccess
{
    public class AreaRepository : IAreaRepository
    {
        private readonly ApplicationDbContext _context;
        public AreaRepository(ApplicationDbContext context)
            => this._context = context;

        public int Create(Area newArea)
        {
            this._context.Areas.Add(newArea);
            return this._context.SaveChanges();
        }

        public List<Area> GetAll() => this._context.Areas.ToList();

        public List<Area> GetUnion(Area filter) => this._context.Areas.Where(a =>
            a.AreaID == filter.AreaID ||
            a.Name == filter.Name
        ).ToList();

        public List<Area> GetIntersection(Area filter) => this._context.Areas.Where(a =>
            a.AreaID == filter.AreaID &&
            a.Name == filter.Name
        ).ToList();

        public int Update(Area target)
        {
            var area = this._context.Areas.First(a => a.AreaID == target.AreaID);
            if (target.Name != null) area.Name = target.Name;
            return this._context.SaveChanges();
        }

        public int Delete(int id)
        {
            this._context.Remove(this._context.Areas.First(a => a.AreaID == id));
            return this._context.SaveChanges();
        }
    }
}