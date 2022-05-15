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

        public int Create(Hotline newHotline)
        {
            this._context.Hotlines.Add(newHotline);
            return this._context.SaveChanges();
        }

        public List<Hotline> GetAll() => this._context.Hotlines.ToList();

        public List<Hotline> GetUnion(Hotline filter) => this._context.Hotlines.Where(h =>
            h.Name == filter.Name ||
            h.Number == filter.Number
        ).ToList();

        public List<Hotline> GetIntersection(Hotline filter) => this._context.Hotlines.Where(h =>
            h.Name == filter.Name &&
            h.Number == filter.Number
        ).ToList();

        public int Update(Hotline target)
        {
            var hotline = this._context.Hotlines.First(h => h.HotlineID == target.HotlineID);
            if (target.Name != null) hotline.Name = target.Name;
            if (target.Number != null) hotline.Number = target.Number;
            return this._context.SaveChanges();
        }

        public int Delete(int id)
        {
            this._context.Remove(this._context.Hotlines.First(h => h.HotlineID == id));
            return this._context.SaveChanges();
        }
    }
}