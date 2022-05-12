using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WEB_Basics_Project.Sql.Data.SQLServer.Models;

namespace WEB_Basics_Project.Sql.Data.SQLServer.DataAccess
{
    public class HotlineRepository : IRepository<Hotline>
    {
        private ApplicationDbContext db { get; set; }
        public HotlineRepository()
        {
            db = new ApplicationDbContext();
        }

        public int Create(Hotline newHotline)
        {
            db.Hotlines.Add(newHotline);
            return db.SaveChanges();
        }

        public List<Hotline> GetAll() => db.Hotlines.ToList();

        public List<Hotline> GetUnion(Hotline filter) => db.Hotlines.Where(h =>
            h.Name == filter.Name ||
            h.Number == filter.Number
        ).ToList();

        public List<Hotline> GetIntersection(Hotline filter) => db.Hotlines.Where(h =>
            h.Name == filter.Name &&
            h.Number == filter.Number
        ).ToList();

        public int Update(Hotline target)
        {
            var hotline = db.Hotlines.First(h => h.HotlineID == target.HotlineID);
            if (target.Name != null) hotline.Name = target.Name;
            if (target.Number != null) hotline.Number = target.Number;
            return db.SaveChanges();
        }

        public int Delete(int id)
        {
            db.Remove(db.Hotlines.First(h => h.HotlineID == id));
            return db.SaveChanges();
        }
    }
}


