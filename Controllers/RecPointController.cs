﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_Basics_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecPointController : Controller
    {
        public IActionResult RecPoint()
        {
            return View();
        }
    }
}
