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
    public class TeaStoresController : Controller
    {
        private readonly DrinkUpContext _context;

        public TeaStoresController(DrinkUpContext context)
        {
            _context = context;
        }

        // GET: TeaStores
        public async Task<IActionResult> Index()
        {
            return View(await _context.TeaStore.ToListAsync());
        }

        // GET: TeaStores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teaStore = await _context.TeaStore
                .FirstOrDefaultAsync(m => m.TeaStoreID == id);
            if (teaStore == null)
            {
                return NotFound();
            }

            return View(teaStore);
        }

        // GET: TeaStores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeaStores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeaStoreID,Name,Url")] TeaStore teaStore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teaStore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teaStore);
        }

        // GET: TeaStores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teaStore = await _context.TeaStore.FindAsync(id);
            if (teaStore == null)
            {
                return NotFound();
            }
            return View(teaStore);
        }

        // POST: TeaStores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeaStoreID,Name,Url")] TeaStore teaStore)
        {
            if (id != teaStore.TeaStoreID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teaStore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeaStoreExists(teaStore.TeaStoreID))
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
            return View(teaStore);
        }

        // GET: TeaStores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teaStore = await _context.TeaStore
                .FirstOrDefaultAsync(m => m.TeaStoreID == id);
            if (teaStore == null)
            {
                return NotFound();
            }

            return View(teaStore);
        }

        // POST: TeaStores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teaStore = await _context.TeaStore.FindAsync(id);
            _context.TeaStore.Remove(teaStore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeaStoreExists(int id)
        {
            return _context.TeaStore.Any(e => e.TeaStoreID == id);
        }
    }
}
