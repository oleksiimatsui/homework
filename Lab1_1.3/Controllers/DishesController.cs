#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DiningRoomWA;
using System.Dynamic;

namespace DiningRoomWA.Controllers
{
    public class DishesController : Controller
    {
        private readonly DiningRoomDBContext _context;

        public DishesController(DiningRoomDBContext context)
        {
            _context = context;
        }

        // GET: Dishes
        public async Task<IActionResult> Index()
        {
            var dishes =  (from d in _context.Dishes select d).ToList();
            return View(dishes);
        }

        // GET: Dishes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes.FirstOrDefaultAsync(m => m.Id == id);

            if (dish == null)
            {
                return NotFound();
            }

            //return View(dish);
            return RedirectToAction("Index", "DishIncludes", new { Id = id });
        }

        // GET: Dishes/Create
        public IActionResult Create()
        {
            ViewData["TypeId"] = new SelectList(_context.Types, "Id", "Name");
            return View();
        }

        // POST: Dishes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Calories,Notes,TypeId")] Dish dish)
        {
            if (IsUnique(dish.Name))
            {
                _context.Add(dish);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "DishIncludes", new { Id = dish.Id });
            }
            return View(dish);
        }

        bool IsUnique(string name)
        {
            var q = (from menu in _context.Dishes
                     where menu.Name == name
                     select menu).ToList();
            if (q.Count == 0) { return true; }
            return false;
        }

        // GET: Dishes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes.FindAsync(id);
            if (dish == null)
            {
                return NotFound();
            }
            ViewData["TypeId"] = new SelectList(_context.Types, "Id", "Id", dish.TypeId);
            return View(dish);
        }

        // POST: Dishes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Calories,Notes,TypeId")] Dish dish)
        {
            if (id != dish.Id)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(dish);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DishExists(dish.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));

            ViewData["TypeId"] = new SelectList(_context.Types, "Id", "Name", dish.TypeId);
            return View(dish);
        }

        // GET: Dishes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes
                .Include(d => d.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dish == null)
            {
                return NotFound();
            }

            return View(dish);
        }

        // POST: Dishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dish = await _context.Dishes.FindAsync(id);
            var menuincludes = from menuinc in _context.MenuIncludes
                               where menuinc.DishId == id
                               select menuinc;
            var dishincludes = from dishinc in _context.DishIncludes
                               where dishinc.DishId == id
                               select dishinc;

            _context.DishIncludes.RemoveRange(dishincludes);
            _context.MenuIncludes.RemoveRange(menuincludes);
            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DishExists(int id)
        {
            return _context.Dishes.Any(e => e.Id == id);
        }
    }
}
