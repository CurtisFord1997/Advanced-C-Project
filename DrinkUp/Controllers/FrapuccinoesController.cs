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
    public class FrapuccinoesController : Controller
    {
        private readonly DrinkUpContext _context;

        public FrapuccinoesController(DrinkUpContext context)
        {
            _context = context;
        }

        // GET: Frapuccinoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Frapuccino.ToListAsync());
        }

        // GET: Frapuccinoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frapuccino = await _context.Frapuccino
                .FirstOrDefaultAsync(m => m.FrapID == id);
            if (frapuccino == null)
            {
                return NotFound();
            }

            return View(frapuccino);
        }

        // GET: Frapuccinoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Frapuccinoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FrapID,FrapType,FrapName")] Frapuccino frapuccino)
        {
            if (ModelState.IsValid)
            {
                _context.Add(frapuccino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(frapuccino);
        }

        // GET: Frapuccinoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frapuccino = await _context.Frapuccino.FindAsync(id);
            if (frapuccino == null)
            {
                return NotFound();
            }
            return View(frapuccino);
        }

        // POST: Frapuccinoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FrapID,FrapType,FrapName")] Frapuccino frapuccino)
        {
            if (id != frapuccino.FrapID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(frapuccino);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FrapuccinoExists(frapuccino.FrapID))
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
            return View(frapuccino);
        }

        // GET: Frapuccinoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frapuccino = await _context.Frapuccino
                .FirstOrDefaultAsync(m => m.FrapID == id);
            if (frapuccino == null)
            {
                return NotFound();
            }

            return View(frapuccino);
        }

        // POST: Frapuccinoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var frapuccino = await _context.Frapuccino.FindAsync(id);
            _context.Frapuccino.Remove(frapuccino);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FrapuccinoExists(int id)
        {
            return _context.Frapuccino.Any(e => e.FrapID == id);
        }
    }
}
