﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkUp.Controllers
{
    public class FrapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
