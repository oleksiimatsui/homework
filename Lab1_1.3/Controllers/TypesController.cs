#nullable disable
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiningRoomWA.Controllers
{
   // [Authorize(Roles = "Admin, User")]
    public class TypesController : Controller
    {
        private readonly DiningRoomDBContext _context;

        public TypesController(DiningRoomDBContext context)
        {
            _context = context;
        }

        // GET: Types
        public async Task<IActionResult> Index()
        {
            return View(await _context.Types.ToListAsync());
        }

        // GET: Types/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.Type = (from Types in _context.Types
                           where Types.Id == id
                           select Types).Include(x => x.Dishes).FirstOrDefault();

            return View();
        }

        // GET: Types/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Types/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Type type)
        {
            if (ModelState.IsValid)
            {
                if (IsUnique(type.Name))
                {
                    _context.Add(type);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(type);
        }

        bool IsUnique(string name)
        {
            var q = (from menu in _context.Types
                     where menu.Name == name
                     select menu).ToList();
            if (q.Count == 0) { return true; }
            return false;
        }

        // GET: Types/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @type = await _context.Types.FindAsync(id);
            if (@type == null)
            {
                return NotFound();
            }
            return View(@type);
        }

        // POST: Types/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Type @type)
        {
            if (id != @type.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@type);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeExists(@type.Id))
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
            return View(@type);
        }

        // GET: Types/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @type = await _context.Types
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@type == null)
            {
                return NotFound();
            }

            return View(@type);
        }

        // POST: Types/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var type = await _context.Types.FindAsync(id);
            var dishes = from dish in _context.Dishes
                         where dish.TypeId == id
                         select dish;
            var menuincludes = from menuinc in _context.MenuIncludes
                               join dish in dishes
                               on menuinc.DishId equals dish.Id
                               select menuinc;

            var dishincludes = from dishinc in _context.DishIncludes
                               join dish in dishes
                               on dishinc.DishId equals dish.Id
                               select dishinc;

            _context.DishIncludes.RemoveRange(dishincludes);
            _context.MenuIncludes.RemoveRange(menuincludes);
            _context.Dishes.RemoveRange(dishes);
            _context.Types.Remove(type);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeExists(int id)
        {
            return _context.Types.Any(e => e.Id == id);
        }
    }
}
