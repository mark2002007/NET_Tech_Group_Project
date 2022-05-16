using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using WEB_Basics_Project.Domain;
using WEB_Basics_Project.Models;
using WEB_Basics_Project.Service.Services;

namespace WEB_Basics_Project.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : Controller
    {
        private readonly IServicesService _servicesService;
        private readonly UserManager<Volunteer> _userManager;

        public ServicesController(IServicesService servicesService, UserManager<Volunteer> userManager)
           => (this._servicesService, this._userManager) = (servicesService, userManager);

        public IActionResult Services()
        {
            ServiceViewModel serviceViewModel = new ServiceViewModel
            {
                Services = this._servicesService.GetAll()
            };
            return View(serviceViewModel);
        }
    }
}
/*Volunteer user = this._userManager.FindByIdAsync(this._userManager.GetUserId(HttpContext.User)).Result;*/