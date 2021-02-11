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
    public class ColdCoffeesController : Controller
    {
        private readonly DrinkUpContext _context;

        public ColdCoffeesController(DrinkUpContext context)
        {
            _context = context;
        }

        // GET: ColdCoffees
        public async Task<IActionResult> Index()
        {
            return View(await _context.ColdCoffee.ToListAsync());
        }

        // GET: ColdCoffees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coldCoffee = await _context.ColdCoffee
                .FirstOrDefaultAsync(m => m.ColdCoffeeID == id);
            if (coldCoffee == null)
            {
                return NotFound();
            }

            return View(coldCoffee);
        }

        // GET: ColdCoffees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ColdCoffees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ColdCoffeeID,ColdCoffeeType,ColdCoffeeName,Caffiene")] ColdCoffee coldCoffee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coldCoffee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coldCoffee);
        }

        // GET: ColdCoffees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coldCoffee = await _context.ColdCoffee.FindAsync(id);
            if (coldCoffee == null)
            {
                return NotFound();
            }
            return View(coldCoffee);
        }

        // POST: ColdCoffees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ColdCoffeeID,ColdCoffeeType,ColdCoffeeName,Caffiene")] ColdCoffee coldCoffee)
        {
            if (id != coldCoffee.ColdCoffeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coldCoffee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColdCoffeeExists(coldCoffee.ColdCoffeeID))
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
            return View(coldCoffee);
        }

        // GET: ColdCoffees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coldCoffee = await _context.ColdCoffee
                .FirstOrDefaultAsync(m => m.ColdCoffeeID == id);
            if (coldCoffee == null)
            {
                return NotFound();
            }

            return View(coldCoffee);
        }

        // POST: ColdCoffees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coldCoffee = await _context.ColdCoffee.FindAsync(id);
            _context.ColdCoffee.Remove(coldCoffee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColdCoffeeExists(int id)
        {
            return _context.ColdCoffee.Any(e => e.ColdCoffeeID == id);
        }
    }
}
