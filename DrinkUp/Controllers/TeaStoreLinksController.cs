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
    public class TeaStoreLinksController : Controller
    {
        private readonly DrinkUpContext _context;

        public TeaStoreLinksController(DrinkUpContext context)
        {
            _context = context;
        }

        // GET: TeaStoreLinks
        public async Task<IActionResult> Index()
        {
            return View(await _context.TeaStoreLink.ToListAsync());
        }

        // GET: TeaStoreLinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teaStoreLink = await _context.TeaStoreLink
                .FirstOrDefaultAsync(m => m.TeaId == id);
            if (teaStoreLink == null)
            {
                return NotFound();
            }

            return View(teaStoreLink);
        }

        // GET: TeaStoreLinks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeaStoreLinks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeaId,TeaStoreId")] TeaStoreLink teaStoreLink)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teaStoreLink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teaStoreLink);
        }

        // GET: TeaStoreLinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teaStoreLink = await _context.TeaStoreLink.FindAsync(id);
            if (teaStoreLink == null)
            {
                return NotFound();
            }
            return View(teaStoreLink);
        }

        // POST: TeaStoreLinks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeaId,TeaStoreId")] TeaStoreLink teaStoreLink)
        {
            if (id != teaStoreLink.TeaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teaStoreLink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeaStoreLinkExists(teaStoreLink.TeaId))
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
            return View(teaStoreLink);
        }

        // GET: TeaStoreLinks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teaStoreLink = await _context.TeaStoreLink
                .FirstOrDefaultAsync(m => m.TeaId == id);
            if (teaStoreLink == null)
            {
                return NotFound();
            }

            return View(teaStoreLink);
        }

        // POST: TeaStoreLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teaStoreLink = await _context.TeaStoreLink.FindAsync(id);
            _context.TeaStoreLink.Remove(teaStoreLink);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeaStoreLinkExists(int id)
        {
            return _context.TeaStoreLink.Any(e => e.TeaId == id);
        }
    }
}
