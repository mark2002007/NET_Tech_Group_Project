using System.Collections.Generic;

using WEB_Basics_Project.Domain;

namespace WEB_Basics_Project.Service.Repositories
{
    public interface IHotlineRepository
    {
        int Create(Hotline newEntity);
        List<Hotline> GetAll();
        List<Hotline> GetUnion(Hotline filter);
        List<Hotline> GetIntersection(Hotline filter);
        int Update(Hotline target);
        int Delete(int id);
    }
}