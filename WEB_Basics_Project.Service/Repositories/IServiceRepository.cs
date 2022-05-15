using System.Collections.Generic;

namespace WEB_Basics_Project.Service.Repositories
{
    public interface IServiceRepository
    {
        int Create(Domain.Service newEntity);
        List<Domain.Service> GetAll();
        List<Domain.Service> GetUnion(Domain.Service filter);
        List<Domain.Service> GetIntersection(Domain.Service filter);
        int Update(Domain.Service target);
        int Delete(int id);
    }
}
