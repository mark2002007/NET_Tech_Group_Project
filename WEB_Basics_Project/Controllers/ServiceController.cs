using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using WEB_Basics_Project.Domain;
using WEB_Basics_Project.Models;
using WEB_Basics_Project.Service.Services;

namespace WEB_Basics_Project.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServicesService _servicesService;
        private readonly UserManager<Volunteer> _userManager;

        public ServiceController(IServicesService servicesService, UserManager<Volunteer> userManager)
           => (this._servicesService, this._userManager) = (servicesService, userManager);

        /// <summary>
        /// Show service page with all service
        /// </summary>
        /// <returns>
        /// Return all service
        /// </returns>
        public IActionResult Index()
        {
            ServicesViewModel serviceViewModel = new ServicesViewModel { Services = this._servicesService.GetAll() };
            return View(serviceViewModel);
        }

        public IActionResult Create()
            => View();

        /// <summary>
        /// Shows service page with service
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateService([Bind("Description")] PostService request)
        {
            Domain.Service service = new Domain.Service
            {
                Description = request.Description,
                VolunteerID = this._userManager.GetUserId(HttpContext.User)
            };
            this._servicesService.Create(service);

            return RedirectToAction(nameof(Index));
        }
    }
}