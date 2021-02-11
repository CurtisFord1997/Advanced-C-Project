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
    public class HotCoffeesController : Controller
    {
        private readonly DrinkUpContext _context;

        public HotCoffeesController(DrinkUpContext context)
        {
            _context = context;
        }

        // GET: HotCoffees
        public async Task<IActionResult> Index()
        {
            return View(await _context.HotCoffee.ToListAsync());
        }

        // GET: HotCoffees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotCoffee = await _context.HotCoffee
                .FirstOrDefaultAsync(m => m.HotCoffeeID == id);
            if (hotCoffee == null)
            {
                return NotFound();
            }

            return View(hotCoffee);
        }

        // GET: HotCoffees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HotCoffees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotCoffeeID,HotCoffeeType,HotCoffeeName")] HotCoffee hotCoffee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotCoffee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotCoffee);
        }

        // GET: HotCoffees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotCoffee = await _context.HotCoffee.FindAsync(id);
            if (hotCoffee == null)
            {
                return NotFound();
            }
            return View(hotCoffee);
        }

        // POST: HotCoffees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HotCoffeeID,HotCoffeeType,HotCoffeeName")] HotCoffee hotCoffee)
        {
            if (id != hotCoffee.HotCoffeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotCoffee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotCoffeeExists(hotCoffee.HotCoffeeID))
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
            return View(hotCoffee);
        }

        // GET: HotCoffees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotCoffee = await _context.HotCoffee
                .FirstOrDefaultAsync(m => m.HotCoffeeID == id);
            if (hotCoffee == null)
            {
                return NotFound();
            }

            return View(hotCoffee);
        }

        // POST: HotCoffees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotCoffee = await _context.HotCoffee.FindAsync(id);
            _context.HotCoffee.Remove(hotCoffee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotCoffeeExists(int id)
        {
            return _context.HotCoffee.Any(e => e.HotCoffeeID == id);
        }
    }
}
