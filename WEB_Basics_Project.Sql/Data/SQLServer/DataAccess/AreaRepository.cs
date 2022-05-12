using System.Collections.Generic;
using System.Linq;
using WEB_Basics_Project.Sql.Data.SQLServer.Models;

namespace WEB_Basics_Project.Sql.Data.SQLServer.DataAccess
{
    public class AreaRepository : IRepository<Area>
    {
        private ApplicationDbContext db { get; set; }
        public AreaRepository()
        {
            db = new ApplicationDbContext();
        }

        public int Create(Area newArea)
        {
            db.Areas.Add(newArea);
            return db.SaveChanges();
        }

        public List<Area> GetAll() => db.Areas.ToList();

        public List<Area> GetUnion(Area filter) => db.Areas.Where(a =>
            a.AreaID == filter.AreaID ||
            a.Name == filter.Name
        ).ToList();

        public List<Area> GetIntersection(Area filter) => db.Areas.Where(a =>
            a.AreaID == filter.AreaID &&
            a.Name == filter.Name
        ).ToList();

        public int Update(Area target)
        {
            var area = db.Areas.First(a => a.AreaID == target.AreaID);
            if (target.Name != null) area.Name = target.Name;
            return db.SaveChanges();
        }

        public int Delete(int id)
        {
            db.Remove(db.Areas.First(a => a.AreaID == id));
            return db.SaveChanges();
        }
    }
}


