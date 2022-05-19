using Microsoft.AspNetCore.Mvc;

namespace WEB_Basics_Project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
            => View();

    }
}