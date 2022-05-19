using Microsoft.AspNetCore.Mvc;

using WEB_Basics_Project.Models;
using WEB_Basics_Project.Service.Services;

namespace WEB_Basics_Project.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IAreaService _areaService;
        private readonly IHotlineService _hotlineService;

        public ContactsController(IAreaService areaService, IHotlineService hotlineService)
            => (this._areaService, this._hotlineService) = (areaService, hotlineService);

        /// <summary>
        /// Show contacts page with hotline
        /// </summary>
        /// <returns>
        /// Return all hotline
        /// </returns>
        public IActionResult Index()
        {
            HotlineViewModel viewModel = new HotlineViewModel
            {
                Areas = this._areaService.GetAll(),
                Hotlines = this._hotlineService.GetAll()
            };

            return View(viewModel);
        }
    }
}