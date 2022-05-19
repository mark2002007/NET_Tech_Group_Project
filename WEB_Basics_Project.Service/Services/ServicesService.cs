using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Identity;

using WEB_Basics_Project.Domain;
using WEB_Basics_Project.Service.Repositories;

namespace WEB_Basics_Project.Service.Services
{
    public class ServicesService : IServicesService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly UserManager<Volunteer> _userManager;

        public ServicesService(IServiceRepository serviceRepository, UserManager<Volunteer> userManager)
          => (this._serviceRepository, this._userManager) = (serviceRepository, userManager);

        /// <summary>
        /// Get all service with contact
        /// </summary>
        /// <returns>
        /// Return all service with contact
        /// </returns>
        public List<ServiceView> GetAll() {

            IEnumerable<Domain.Service> servicesResponse = this._serviceRepository.GetAll();

            var services = new List<ServiceView>();

            foreach (var service in servicesResponse)
            {
                Volunteer user = this._userManager.Users.FirstOrDefault(user => user.Id == service.VolunteerID);
                services.Add(new ServiceView
                {
                    ServiceDescription = service.Description,
                    FirstName = user.FirstName,
                    PhoneNumber = user.PhoneNumber
                });
            }

            return services;
        }

        /// <summary>
        /// Create new service
        /// </summary>
        /// <returns></returns>
        public int Create(Domain.Service service)
            => this._serviceRepository.Create(service);
    }
}