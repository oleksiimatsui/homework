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

namespace DiningRoomWA.Controllers
{
    public class MenuIncludesController : Controller
    {
        private readonly DiningRoomDBContext _context;

        public MenuIncludesController(DiningRoomDBContext context)
        {
            _context = context;
        }

        // GET: MenuIncludes
        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.menuId = id;
            ViewBag.menuName = _context.Menus.Where(m => m.Id == id).SingleOrDefault().Name;
            var diningRoomDBContext = _context.MenuIncludes.Where(m => m.MenuId == id).Include(m => m.Dish);
            return View(await diningRoomDBContext.ToListAsync());
        }

        // GET: MenuIncludes/Details/5
           
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuInclude = await _context.MenuIncludes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menuInclude == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "DishIncludes", new { Id = menuInclude.DishId });
        }

        // GET: MenuIncludes/Create
        public IActionResult Create(int? id)
        {
            ViewData["DishId"] = new SelectList(_context.Dishes.OrderBy(x => x.Name), "Id", "Name");
            ViewBag.MenuId = id;
            ViewBag.MenuName = _context.Menus.Where(m => m.Id == id).SingleOrDefault().Name;
            return View();
        }

        // POST: MenuIncludes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuId,DishId,Cost")] MenuInclude menuInclude)
        {
            try
            {
                _context.Add(menuInclude);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                ViewData["DishId"] = new SelectList(_context.Dishes, "Id", "Name");
                ViewBag.MenuId = menuInclude.MenuId;
                ViewBag.MenuName = _context.Menus.Where(m => m.Id == menuInclude.MenuId).SingleOrDefault().Name;
                return View(menuInclude);
            }
            return RedirectToAction("Index", "MenuIncludes", new { id = menuInclude.MenuId });
        }

        // GET: MenuIncludes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuInclude = await _context.MenuIncludes.FindAsync(id);
            if (menuInclude == null)
            {
                return NotFound();
            }
            ViewData["DishId"] = new SelectList(_context.Dishes, "Id", "Name", menuInclude.DishId);
            ViewBag.MenuId = menuInclude.MenuId;
            ViewBag.MenuName = _context.Menus.Where(m => m.Id == menuInclude.MenuId).SingleOrDefault().Name;


            return View(menuInclude);
        }

        // POST: MenuIncludes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MenuId,DishId,Cost")] MenuInclude menuInclude)
        {
            if (id != menuInclude.Id)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(menuInclude);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuIncludeExists(menuInclude.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }


            ViewData["DishId"] = new SelectList(_context.Dishes, "Id", "Id", menuInclude.DishId);
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Id", menuInclude.MenuId);

            return RedirectToAction("Index", "MenuIncludes", new { id = menuInclude.MenuId });

        }

        // GET: MenuIncludes/Delete/5
        public async Task<IActionResult> Delete(int? id, string menuName)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuInclude = await _context.MenuIncludes
                .Include(m => m.Dish)
                .Include(m => m.Menu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menuInclude == null)
            {
                return NotFound();
            }

            ViewBag.MenuName = menuName;
           
            return View(menuInclude);
        }

        // POST: MenuIncludes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuInclude = _context.MenuIncludes.Where(x => x.Id == id).First();
            _context.MenuIncludes.Remove(menuInclude);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "MenuIncludes", new { id = menuInclude.MenuId });
        }

        private bool MenuIncludeExists(int id)
        {
            return _context.MenuIncludes.Any(e => e.Id == id);
        }

        public ActionResult Export(int menuId)
        {
            using (XLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled))
            {
                var menuName = _context.Menus.Where(x => x.Id == menuId).First().Name;

                var worksheet = workbook.Worksheets.Add(menuName);

                worksheet.Cell("A1").Value = "Назва";
                worksheet.Cell("A2").Value = "Вартість";
                worksheet.Row(1).Style.Font.Bold = true;

                var pair = (from dish in _context.Dishes
                            join menuinclude in _context.MenuIncludes
                            on dish.Id equals menuinclude.DishId
                            where menuinclude.MenuId == menuId
                            select new { Name = dish.Name, Cost = menuinclude.Cost }).ToList();


                //нумерація рядків/стовпчиків починається з індекса 1 (не 0)
                for (int i = 0; i < pair.Count; i++)
                { 
                    worksheet.Cell(i + 2, 1).Value = pair[i].Name;
                    worksheet.Cell(i + 2, 2).Value = pair[i].Cost;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Flush();

                    return new FileContentResult(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        //змініть назву файла відповідно до тематики Вашого проєкту

                        FileDownloadName = $"Menu_{DateTime.UtcNow.ToShortDateString()}.xlsx"
                    };
                }
            }
        }

    }
}
