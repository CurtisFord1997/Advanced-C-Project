using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DrinkUp.Data;
using DrinkUp.Models;

namespace DrinkUp.Controllers
{
    public class PopsController : Controller
    {
        private readonly DrinkUpContext _context;

        public PopsController(DrinkUpContext context)
        {
            _context = context;
        }

        // GET: Pops
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pop.ToListAsync());
        }

        // GET: Pops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pop = await _context.Pop
                .FirstOrDefaultAsync(m => m.PopId == id);
            if (pop == null)
            {
                return NotFound();
            }

            return View(pop);
        }

        // GET: Pops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PopId,PopName,FruitFlavor,Diet,PackageType,PreferTemp,Sugar,NumDrinkPerDay")] Pop pop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pop);
        }

        // GET: Pops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pop = await _context.Pop.FindAsync(id);
            if (pop == null)
            {
                return NotFound();
            }
            return View(pop);
        }

        // POST: Pops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PopId,PopName,FruitFlavor,Diet,PackageType,PreferTemp,Sugar,NumDrinkPerDay")] Pop pop)
        {
            if (id != pop.PopId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PopExists(pop.PopId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pop);
        }

        // GET: Pops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pop = await _context.Pop
                .FirstOrDefaultAsync(m => m.PopId == id);
            if (pop == null)
            {
                return NotFound();
            }

            return View(pop);
        }

        // POST: Pops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pop = await _context.Pop.FindAsync(id);
            _context.Pop.Remove(pop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PopExists(int id)
        {
            return _context.Pop.Any(e => e.PopId == id);
        }
    }
}
