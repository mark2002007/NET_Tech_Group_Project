using System.Collections.Generic;

using WEB_Basics_Project.Domain;

namespace WEB_Basics_Project.Service.Repositories
{
    public interface IVolunteerRepository
    {
        int Create(Volunteer newEntity);
        List<Volunteer> GetAll();
        List<Volunteer> GetUnion(Volunteer filter);
        List<Volunteer> GetIntersection(Volunteer filter);
        int Update(Volunteer target);
        int Delete(string id);
    }
}