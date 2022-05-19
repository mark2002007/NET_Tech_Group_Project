using Microsoft.AspNetCore.Mvc;

namespace WEB_Basics_Project.Controllers
{
    public class SheltersController : Controller
    {
        public IActionResult Index()
            => View();

    }
}