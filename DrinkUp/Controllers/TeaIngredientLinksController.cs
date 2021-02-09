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
    public class TeaIngredientLinksController : Controller
    {
        private readonly DrinkUpContext _context;

        public TeaIngredientLinksController(DrinkUpContext context)
        {
            _context = context;
        }

        // GET: TeaIngredientLinks
        public async Task<IActionResult> Index()
        {
            return View(await _context.TeaIngredientLink.ToListAsync());
        }

        // GET: TeaIngredientLinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teaIngredientLink = await _context.TeaIngredientLink
                .FirstOrDefaultAsync(m => m.TeaId == id);
            if (teaIngredientLink == null)
            {
                return NotFound();
            }

            return View(teaIngredientLink);
        }

        // GET: TeaIngredientLinks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeaIngredientLinks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeaId,TeaIngredientID")] TeaIngredientLink teaIngredientLink)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teaIngredientLink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teaIngredientLink);
        }

        // GET: TeaIngredientLinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teaIngredientLink = await _context.TeaIngredientLink.FindAsync(id);
            if (teaIngredientLink == null)
            {
                return NotFound();
            }
            return View(teaIngredientLink);
        }

        // POST: TeaIngredientLinks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeaId,TeaIngredientID")] TeaIngredientLink teaIngredientLink)
        {
            if (id != teaIngredientLink.TeaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teaIngredientLink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeaIngredientLinkExists(teaIngredientLink.TeaId))
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
            return View(teaIngredientLink);
        }

        // GET: TeaIngredientLinks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teaIngredientLink = await _context.TeaIngredientLink
                .FirstOrDefaultAsync(m => m.TeaId == id);
            if (teaIngredientLink == null)
            {
                return NotFound();
            }

            return View(teaIngredientLink);
        }

        // POST: TeaIngredientLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teaIngredientLink = await _context.TeaIngredientLink.FindAsync(id);
            _context.TeaIngredientLink.Remove(teaIngredientLink);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeaIngredientLinkExists(int id)
        {
            return _context.TeaIngredientLink.Any(e => e.TeaId == id);
        }
    }
}
