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
    public class TeaIngredientsController : Controller
    {
        private readonly DrinkUpContext _context;

        public TeaIngredientsController(DrinkUpContext context)
        {
            _context = context;
        }

        // GET: TeaIngredients
        public async Task<IActionResult> Index()
        {
            return View(await _context.TeaIngredient.ToListAsync());
        }

        // GET: TeaIngredients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teaIngredient = await _context.TeaIngredient
                .FirstOrDefaultAsync(m => m.TeaIngredientID == id);
            if (teaIngredient == null)
            {
                return NotFound();
            }

            return View(teaIngredient);
        }

        // GET: TeaIngredients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeaIngredients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeaIngredientID,IngredientName")] TeaIngredient teaIngredient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teaIngredient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teaIngredient);
        }

        // GET: TeaIngredients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teaIngredient = await _context.TeaIngredient.FindAsync(id);
            if (teaIngredient == null)
            {
                return NotFound();
            }
            return View(teaIngredient);
        }

        // POST: TeaIngredients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeaIngredientID,IngredientName")] TeaIngredient teaIngredient)
        {
            if (id != teaIngredient.TeaIngredientID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teaIngredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeaIngredientExists(teaIngredient.TeaIngredientID))
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
            return View(teaIngredient);
        }

        // GET: TeaIngredients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teaIngredient = await _context.TeaIngredient
                .FirstOrDefaultAsync(m => m.TeaIngredientID == id);
            if (teaIngredient == null)
            {
                return NotFound();
            }

            return View(teaIngredient);
        }

        // POST: TeaIngredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teaIngredient = await _context.TeaIngredient.FindAsync(id);
            _context.TeaIngredient.Remove(teaIngredient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeaIngredientExists(int id)
        {
            return _context.TeaIngredient.Any(e => e.TeaIngredientID == id);
        }
    }
}
