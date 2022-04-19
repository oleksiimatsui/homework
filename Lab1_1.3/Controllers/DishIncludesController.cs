#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DiningRoomWA;

namespace DiningRoomWA.Controllers
{
    public class DishIncludesController : Controller
    {
        private readonly DiningRoomDBContext _context;

        public DishIncludesController(DiningRoomDBContext context)
        {
            _context = context;
        }

        // GET: DishIncludes
        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.dishId = id;
            ViewBag.dishName = _context.Dishes.Where(d => d.Id == id).SingleOrDefault().Name;
            ViewBag.dish = _context.Dishes.Where(d => d.Id == id).Include(m => m.Type).SingleOrDefault();

            double? mass = 0;
            var dishincls = from di in _context.DishIncludes
                             join dish in _context.Dishes
                             on di.DishId equals dish.Id
                             where dish.Id == id
                             select di.Mass;

            foreach (var ingMass in dishincls )
            {
                mass += ingMass;
            }
            ViewBag.dishMass = mass;

            var dishinclude = _context.DishIncludes.Where(d => d.DishId == id).Include(d => d.Ingredient);
            return View(await dishinclude.ToListAsync());
        }

        // GET: DishIncludes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dishInclude = await _context.DishIncludes
                .Include(d => d.Dish)
                .Include(d => d.Ingredient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dishInclude == null)
            {
                return NotFound();
            }

            return View(dishInclude);
        }

        // GET: DishIncludes/Create
        public IActionResult Create(int id)
        {
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "Id", "Name");
            ViewBag.DishId = id;
            ViewBag.DishName = _context.Dishes.Where(m => m.Id == id).SingleOrDefault().Name;
            return View();
        }

        // POST: DishIncludes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DishId, IngredientId, Mass")] DishInclude dishInclude)
        {
            try
            {
                _context.Add(dishInclude);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                ViewData["IngredientId"] = new SelectList(_context.Ingredients, "Id", "Name");
                ViewBag.DishId = dishInclude.DishId;
                ViewBag.DishName = _context.Dishes.Where(m => m.Id == dishInclude.DishId).SingleOrDefault().Name;
                return View(dishInclude);
            }
           
            return RedirectToAction("Index", "DishIncludes", new { id = dishInclude.DishId });
        }

        // GET: DishIncludes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dishInclude = await _context.DishIncludes.FindAsync(id);
            if (dishInclude == null)
            {
                return NotFound();
            }
            ViewData["DishId"] = new SelectList(_context.Dishes, "Id", "Name", dishInclude.DishId);
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "Id", "Name", dishInclude.IngredientId);
            return View(dishInclude);
        }

        // POST: DishIncludes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DishId,IngredientId,Mass")] DishInclude dishInclude)
        {
            if (id != dishInclude.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dishInclude);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DishIncludeExists(dishInclude.Id))
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
            ViewData["DishId"] = new SelectList(_context.Dishes, "Id", "Name", dishInclude.DishId);
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "Id", "Name", dishInclude.IngredientId);
            return View(dishInclude);
        }

        // GET: DishIncludes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dishInclude = await _context.DishIncludes
                .Include(d => d.Dish)
                .Include(d => d.Ingredient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dishInclude == null)
            {
                return NotFound();
            }

            return View(dishInclude);
        }

        // POST: DishIncludes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dishInclude = await _context.DishIncludes.FindAsync(id);
            _context.DishIncludes.Remove(dishInclude);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "DishIncludes", new { id = dishInclude.DishId });
        }

        private bool DishIncludeExists(int id)
        {
            return _context.DishIncludes.Any(e => e.Id == id);
        }
    }
}
