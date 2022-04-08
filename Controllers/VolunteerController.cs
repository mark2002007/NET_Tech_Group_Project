using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_Basics_Project.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VolunteerController : Controller
    {
        public IActionResult Volunteer()
        {
            return View();
        }
    }
}
