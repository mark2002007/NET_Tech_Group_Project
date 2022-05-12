using System.Collections.Generic;
using WEB_Basics_Project.Sql.Data.SQLServer.Models;

namespace WEB_Basics_Project.Sql.Data.SQLServer.DataAccess
{
    public interface IRepository<T>
    {
        int Create(T newEntity);
        List<T> GetAll();
        List<T> GetUnion(T filter);
        List<T> GetIntersection(T filter);
        int Update(T target);
        int Delete(int id);
    }
}