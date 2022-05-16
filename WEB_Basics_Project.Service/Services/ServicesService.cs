using System.Collections.Generic;

using WEB_Basics_Project.Service.Repositories;

namespace WEB_Basics_Project.Service.Services
{
    public class ServicesService : IServicesService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServicesService(IServiceRepository serviceRepository)
            => this._serviceRepository = serviceRepository;

        public List<Domain.Service> GetAll()
            => this._serviceRepository.GetAll();
    }
}