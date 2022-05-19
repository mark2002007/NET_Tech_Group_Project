using System.Collections.Generic;

using WEB_Basics_Project.Domain;

namespace WEB_Basics_Project.Service.Services
{
    public interface IServicesService
    {
        List<ServiceView> GetAll();
        int Create(Domain.Service service);
    }
}