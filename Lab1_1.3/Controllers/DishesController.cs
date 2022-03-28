#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DiningRoomWebApplication;

namespace DiningRoomWebApplication.Controllers
{
    public class DishesController : Controller
    {
        private readonly DiningRoomDBContext _context;

        public DishesController(DiningRoomDBContext context)
        {
            _context = context;
        }

        // GET: Dishes
        public async Task<IActionResult> Index(int id, string? name)
        {
            if (id == null) return RedirectToAction("Index");
            //знаходження страв за меню
            ViewBag.MenuId = id;

            ViewBag.MenuName = _context.Menus.Where(m => m.Id == id).FirstOrDefault().Name;

            var menuinclude = _context.MenuIncludes.Where(x => x.MenuId == id);
            IQueryable<Dish> dish = null;
            if (menuinclude != null)
            {
                dish = (from dishes in _context.Dishes
                       join menuincludes in menuinclude on dishes.Id equals menuincludes.DishId
                       select dishes).Include(d => d.Type); 
            }
            return View(await dish.ToListAsync());
        }

        // GET: Dishes/Details/5
        public async Task<IActionResult> Details(int? id, int menuId)
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
            ViewBag.MenuId = menuId;
            ViewBag.MenuName = _context.Menus.Where(m => m.Id == menuId).FirstOrDefault().Name;
            
            return View(dish);
        }

        // GET: Dishes/Create
        public IActionResult Create(int menuId)
        {
            ViewData["TypeId"] = new SelectList(_context.Types, "Id", "Name");
            ViewBag.MenuId = menuId;
            ViewBag.MenuName = _context.Menus.Where(m => m.Id == menuId).FirstOrDefault().Name;
            return View();
        }

        // POST: Dishes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int menuId, [Bind("Id,Name,Calories,Notes,TypeId")] Dish dish)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dish);
                await _context.SaveChangesAsync();
                _context.MenuIncludes.Add(new MenuInclude { DishId = dish.Id, MenuId = menuId });
                await _context.SaveChangesAsync();
            }
            //ViewData["TypeId"] = new SelectList(_context.Types, "Id", "Id", dish.TypeId);
            //return View(dish);
            return RedirectToAction("Index", "Dishes", new { id = menuId, name = _context.Menus.Where(c => c.Id == menuId).FirstOrDefault().Name });
        }

        // GET: Dishes/Add
        public IActionResult Add(int menuId)
        {
           
            ViewData["TypeId"] = new SelectList(_context.Types, "Id", "Name");
            ViewData["DishId"] = new SelectList(_context.Dishes, "Id", "Name");
            ViewBag.MenuId = menuId;
            ViewBag.MenuName = _context.Menus.Where(m => m.Id == menuId).FirstOrDefault().Name;
            return View();
        }

        // POST: Dishes/Add
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int menuId, [Bind("Id")] Dish dish)
        {
            if (ModelState.IsValid)
            {
                _context.MenuIncludes.Add(new MenuInclude { DishId = dish.Id, MenuId = menuId });
                await _context.SaveChangesAsync();
            }
            //ViewData["TypeId"] = new SelectList(_context.Types, "Id", "Id", dish.TypeId);
            //return View(dish);
            return RedirectToAction("Index", "Dishes", new { id = menuId, name = _context.Menus.Where(c => c.Id == menuId).FirstOrDefault().Name });
        }

        // GET: Dishes/Edit/5
        public async Task<IActionResult> Edit(int? id, int menuId)
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
            ViewData["TypeId"] = new SelectList(_context.Types, "Id", "Name", dish.TypeId);
            
            ViewBag.MenuName = _context.Menus.Where(m => m.Id == menuId).FirstOrDefault().Name;
            ViewBag.MenuId = menuId;
            return View(dish);
        }

        // POST: Dishes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int menuId, [Bind("Id,Name,Calories,Notes,TypeId")] Dish dish)
        {
            if (id != dish.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
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
                return RedirectToAction("Index", "Dishes", new { id = menuId, name = _context.Menus.Where(c => c.Id == menuId).FirstOrDefault().Name });
            }
            ViewData["TypeId"] = new SelectList(_context.Types, "Id", "Name", dish.TypeId);
            return RedirectToAction("Index", "Dishes", new { id = menuId, name = _context.Menus.Where(c => c.Id == menuId).FirstOrDefault().Name });

        }

        // GET: Dishes/Delete/5
        public async Task<IActionResult> Delete(int? id, int menuId)
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
            ViewBag.MenuId = menuId;
            ViewBag.MenuName = _context.Menus.Where(m => m.Id == menuId).FirstOrDefault().Name;
            return View(dish);
        }

        // POST: Dishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int menuId, [Bind("Id")] Dish dish)
        {
           // var dish = await _context.Dishes.FindAsync(id);
            var menuinclude = _context.MenuIncludes.Where(x => x.DishId == dish.Id && x.MenuId == menuId).FirstOrDefault<MenuInclude>();
           // _context.Dishes.Remove(dish);
            _context.MenuIncludes.Remove(menuinclude);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("Index", "Dishes", new { id = menuId, name = _context.Menus.Where(c => c.Id == menuId).FirstOrDefault().Name });
        }

        private bool DishExists(int id)
        {
            return _context.Dishes.Any(e => e.Id == id);
        }
    }
}
