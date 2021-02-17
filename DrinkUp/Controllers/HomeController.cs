using DrinkUp.Data;
using DrinkUp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkUp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DrinkUpContext _context;

        public HomeController(DrinkUpContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: TeaTags
        public async Task<IActionResult> Tea()
        {
            return View(await _context.TeaTags.ToListAsync());
        }

        public async Task<IActionResult> Pop()
        {
            return View(await _context.TeaTags.ToListAsync());
        }

        public async Task<IActionResult> Coffee()
        {
            return View(await _context.Coffee.ToListAsync());
        }

        public async Task<IActionResult> HotCoffee()
        {
            return View(await _context.HotCoffee.ToListAsync());
        }

        public async Task<IActionResult> ColdCoffee()
        {
            return View(await _context.ColdCoffee.ToListAsync());
        }

        public async Task<IActionResult> Frap()
        {
            return View(await _context.Frapuccino.ToListAsync());
        }
        public async Task<IActionResult> About()
        {
            ViewData["Message"] = "Your application description page.";

            return View(await _context.TeaTags.ToListAsync());
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
