using System.Collections.Generic;

namespace WEB_Basics_Project.Service.Services
{
    public interface IServicesService
    {
        List<Domain.Service> GetAll();
    }
}