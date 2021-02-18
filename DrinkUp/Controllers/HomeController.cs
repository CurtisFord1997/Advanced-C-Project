using DrinkUp.Data;
using DrinkUp.Models;
using DrinkUp.Models.ViewModels;
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
        public async Task<ActionResult> Tea()
        {
            
            TeaViewModel model = new TeaViewModel
            {
                TeaList = _context.Tea.ToList(),
                TeaIngredientsList = _context.TeaIngredient.ToList(),
                TeaIngredientsLinkList = _context.TeaIngredientLink.ToList(),
                TeaStoreList = _context.TeaStore.ToList(),
                TeaStoreLinkList = _context.TeaStoreLink.ToList(),
                TeaTagsList = _context.TeaTags.ToList(),
                TeaTagsLinksList = _context.TeaTagsLink.ToList()
            };
            

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> TeaResults(String caffeine, String[] brew, String[] teaType, int[] teaTag)
        {
            List<Tea> tTeas = new List<Tea>();
            
            if (!String.IsNullOrEmpty(caffeine))
            {
                //List<Tea> tTeas = new List<Tea>();
                var teas = from m in _context.Tea
                           select m;
                if (caffeine == "Yes")
                {
                    teas = teas.Where(s => s.Caffene != 'N' & s.Caffene != 'U');
                }else if(caffeine == "No")
                {
                    teas = teas.Where(s => s.Caffene == 'N');
                }
                else
                {
                    teas = teas.Where(s => s.Caffene != ' ');
                }
                tTeas = teas.ToList<Tea>();
            }

            
            if (brew.Length > 0)
            {
                List<Tea> teTea = new List<Tea>();
                var tempTeas = from m in tTeas 
                              select m;
                foreach(string brewT in brew){
                    tempTeas = tempTeas.Where(s => s.BrewType.Contains(brewT));
                    teTea.AddRange(tempTeas.ToList<Tea>());
                }

                tTeas = teTea;
            }

            if (teaType.Length > 0)
            {
                List<Tea> teTea = new List<Tea>();
                var tempTeas = from m in tTeas
                               select m;
                foreach (string typeT in teaType)
                {
                    tempTeas = tempTeas.Where(s => s.TeaType.Contains(typeT));
                    teTea.AddRange(tempTeas.ToList<Tea>());
                }

                tTeas = teTea;
            }

            if (teaTag.Length > 0)
            {
                List<TeaTagsLink> teTags = new List<TeaTagsLink>();
                
                foreach (int tagID in teaTag)
                {
                    var tempTeaIDs = from n in _context.TeaTagsLink
                                     select n;
                    tempTeaIDs = tempTeaIDs.Where(s => s.TeaTagID.ToString() == tagID.ToString());
                    teTags.AddRange(tempTeaIDs.ToList<TeaTagsLink>());
                }

                List<Tea> teTea = new List<Tea>();
                var tempTeas = from m in tTeas
                               select m;
                foreach (var group in teTags.GroupBy(item => item.TeaId))
                {
                    teTea.AddRange(tempTeas.Where(s => s.TeaID == group.Key));
                }

                tTeas = teTea;
            }

            TeaViewModel model = new TeaViewModel
            {
                TeaList = tTeas,
                TeaIngredientsList = _context.TeaIngredient.ToList(),
                TeaIngredientsLinkList = _context.TeaIngredientLink.ToList(),
                TeaStoreList = _context.TeaStore.ToList(),
                TeaStoreLinkList = _context.TeaStoreLink.ToList(),
                TeaTagsList = _context.TeaTags.ToList(),
                TeaTagsLinksList = _context.TeaTagsLink.ToList()
            };
            return View(model);
        }

        public async Task<IActionResult> Pop()
        {
            return View(await _context.Pop.ToListAsync());
            ViewData["Message"] = "Your application description page.";
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
