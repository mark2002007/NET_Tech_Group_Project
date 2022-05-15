using System.Collections.Generic;

using WEB_Basics_Project.Domain;

namespace WEB_Basics_Project.Service.Repositories
{
    public interface IAreaRepository
    {
        int Create(Area newEntity);
        List<Area> GetAll();
        List<Area> GetUnion(Area filter);
        List<Area> GetIntersection(Area filter);
        int Update(Area target);
        int Delete(int id);
    }
}