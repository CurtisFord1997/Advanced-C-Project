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
    public class TeaTagsController : Controller
    {
        private readonly DrinkUpContext _context;

        public TeaTagsController(DrinkUpContext context)
        {
            _context = context;
        }

        // GET: TeaTags
        public async Task<IActionResult> Index()
        {
            return View(await _context.TeaTags.ToListAsync());
        }

        // GET: TeaTags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teaTags = await _context.TeaTags
                .FirstOrDefaultAsync(m => m.TeaTagID == id);
            if (teaTags == null)
            {
                return NotFound();
            }

            return View(teaTags);
        }

        // GET: TeaTags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeaTags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeaTagID,Tag")] TeaTags teaTags)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teaTags);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teaTags);
        }

        // GET: TeaTags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teaTags = await _context.TeaTags.FindAsync(id);
            if (teaTags == null)
            {
                return NotFound();
            }
            return View(teaTags);
        }

        // POST: TeaTags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeaTagID,Tag")] TeaTags teaTags)
        {
            if (id != teaTags.TeaTagID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teaTags);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeaTagsExists(teaTags.TeaTagID))
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
            return View(teaTags);
        }

        // GET: TeaTags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teaTags = await _context.TeaTags
                .FirstOrDefaultAsync(m => m.TeaTagID == id);
            if (teaTags == null)
            {
                return NotFound();
            }

            return View(teaTags);
        }

        // POST: TeaTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teaTags = await _context.TeaTags.FindAsync(id);
            _context.TeaTags.Remove(teaTags);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeaTagsExists(int id)
        {
            return _context.TeaTags.Any(e => e.TeaTagID == id);
        }
    }
}
