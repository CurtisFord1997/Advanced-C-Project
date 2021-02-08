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
    public class TeaTagsLinksController : Controller
    {
        private readonly DrinkUpContext _context;

        public TeaTagsLinksController(DrinkUpContext context)
        {
            _context = context;
        }

        // GET: TeaTagsLinks
        public async Task<IActionResult> Index()
        {
            return View(await _context.TeaTagsLink.ToListAsync());
        }

        // GET: TeaTagsLinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teaTagsLink = await _context.TeaTagsLink
                .FirstOrDefaultAsync(m => m.TeaId == id);
            if (teaTagsLink == null)
            {
                return NotFound();
            }

            return View(teaTagsLink);
        }

        // GET: TeaTagsLinks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeaTagsLinks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeaTagID,TeaId")] TeaTagsLink teaTagsLink)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teaTagsLink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teaTagsLink);
        }

        // GET: TeaTagsLinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teaTagsLink = await _context.TeaTagsLink.FindAsync(id);
            if (teaTagsLink == null)
            {
                return NotFound();
            }
            return View(teaTagsLink);
        }

        // POST: TeaTagsLinks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeaTagID,TeaId")] TeaTagsLink teaTagsLink)
        {
            if (id != teaTagsLink.TeaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teaTagsLink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeaTagsLinkExists(teaTagsLink.TeaId))
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
            return View(teaTagsLink);
        }

        // GET: TeaTagsLinks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teaTagsLink = await _context.TeaTagsLink
                .FirstOrDefaultAsync(m => m.TeaId == id);
            if (teaTagsLink == null)
            {
                return NotFound();
            }

            return View(teaTagsLink);
        }

        // POST: TeaTagsLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teaTagsLink = await _context.TeaTagsLink.FindAsync(id);
            _context.TeaTagsLink.Remove(teaTagsLink);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeaTagsLinkExists(int id)
        {
            return _context.TeaTagsLink.Any(e => e.TeaId == id);
        }
    }
}
