#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DiningRoomWA;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;

namespace DiningRoomWA.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly DiningRoomDBContext _context;

        public IngredientsController(DiningRoomDBContext context)
        {
            _context = context;
        }

        // GET: Ingredients
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ingredients.ToListAsync());
        }

        // GET: Ingredients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.Ingredient = (from Ingredients in _context.Ingredients
                                  where Ingredients.Id == id
                                  select Ingredients).FirstOrDefault();

            ViewBag.Dishes = from dishes in _context.Dishes
                             join dishincludes in _context.DishIncludes
                             on dishes.Id equals dishincludes.DishId
                             where dishincludes.IngredientId == id
                             select dishes;

            return View();
        }

        // GET: Ingredients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingredient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ingredient);
        }

        // GET: Ingredients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return View(ingredient);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Ingredient ingredient)
        {
            if (id != ingredient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredientExists(ingredient.Id))
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
            return View(ingredient);
        }

        // GET: Ingredients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);

            var dishincludes = from dishinc in _context.DishIncludes
                               where dishinc.IngredientId == id
                               select dishinc;

            _context.DishIncludes.RemoveRange(dishincludes);

            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredientExists(int id)
        {
            return _context.Ingredients.Any(e => e.Id == id);
        }
        //public async Task<IActionResult> Import(IXLWorksheet sheet)
        //{
        //    foreach (IXLRow row in sheet.RowsUsed().Skip(1))
        //    {
        //        try{
        //            Ingredient ingredient = new Ingredient();
        //            ingredient.Name = row.Cell(2).Value.ToString();
        //            _context.Ingredients.Add(ingredient);
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch (Exception e)
        //        {
        //            //logging самостійно :)
        //            return RedirectToAction(nameof(Index));
        //        }
        //        _context.SaveChanges();
        //        return RedirectToAction(nameof(Index));

        //    }
        //}
    }
}
