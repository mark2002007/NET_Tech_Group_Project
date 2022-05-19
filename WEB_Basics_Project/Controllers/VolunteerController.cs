using Microsoft.AspNetCore.Mvc;

namespace WEB_Basics_Project.Controllers
{
    public class VolunteerController : Controller
    {
        public IActionResult Index()
            => View();

    }
}