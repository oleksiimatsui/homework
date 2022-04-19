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
using ClosedXML.Excel;

namespace DiningRoomWA.Controllers
{
    public class ImportController : Controller
    {
        private readonly DiningRoomDBContext _context;

        public ImportController(DiningRoomDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Import(IFormFile fileExcel)
        {
            if (ModelState.IsValid)
            {
                if (fileExcel != null)
                {
                    _context.Ingredients.RemoveRange();
                    _context.Dishes.RemoveRange();
                    _context.Menus.RemoveRange();
                    _context.Types.RemoveRange();
                    _context.MenuIncludes.RemoveRange();
                    _context.DishIncludes.RemoveRange();

                    using (var stream = new FileStream(fileExcel.FileName, FileMode.Create))
                    {
                        await fileExcel.CopyToAsync(stream);
                        using (XLWorkbook workBook = new XLWorkbook(stream, XLEventTracking.Disabled))
                        {
                            var sheets = workBook.Worksheets.ToList();
                            MenusImport(sheets[4]);
                            TypesImport(sheets[3]);
                            DishesImport(sheets[2]);
                            IngredientsImport(sheets[0]);
                            MenuIncludesImport(sheets[5]);
                            DishIncludesImport(sheets[1]);
                        }
                    }
                }

                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }



        public async void MenusImport(IXLWorksheet sheet)
        {
            foreach (IXLRow row in sheet.RowsUsed().Skip(1))
            {
                try
                {
                    Menu menu = new Menu();
                    menu.Name = row.Cell(2).Value.ToString();
                    menu.Id = (int)row.Cell(1).Value;
                    _context.Menus.Add(menu);
                }
                catch (Exception e)
                {
                    //logging самостійно :)

                }
            }
        }

        public async void TypesImport(IXLWorksheet sheet)
        {
            foreach (IXLRow row in sheet.RowsUsed().Skip(1))
            {
                try
                {
                    Type type = new Type();
                    type.Id = (int)row.Cell(1).Value;
                    type.Name = row.Cell(2).Value.ToString();
                    _context.Types.Add(type);
                }
                catch (Exception e)
                {
                    //logging самостійно :)
                }
            }
        }
        public async void DishesImport(IXLWorksheet sheet)
        {
            foreach (IXLRow row in sheet.RowsUsed().Skip(1))
            {
                try
                {
                    Dish dish = new Dish();
                    dish.Id = (int)row.Cell(1).Value;
                    dish.Name = row.Cell(2).Value.ToString();
                    dish.TypeId = (int)row.Cell(3).Value;
                    dish.Calories = (int)row.Cell(4).Value;
                    dish.Notes = row.Cell(5).ToString();

                    _context.Dishes.Add(dish);
                }
                catch (Exception e)
                {
                    //logging самостійно :)

                }
            }
        }

        public async void IngredientsImport(IXLWorksheet sheet)
        {
            foreach (IXLRow row in sheet.RowsUsed().Skip(1))
            {
                try
                {
                    Ingredient ingredient = new Ingredient();
                    ingredient.Id = (int)row.Cell(1).Value;
                    ingredient.Name = row.Cell(2).Value.ToString();
                    _context.Ingredients.Add(ingredient);
                }
                catch (Exception e)
                {
                    //logging самостійно :)
                }
            }
        }

        public async void MenuIncludesImport(IXLWorksheet sheet)
        {
            foreach (IXLRow row in sheet.RowsUsed().Skip(1))
            {
                try
                {
                    MenuInclude menuinclude = new MenuInclude();
                    menuinclude.Id = (int)row.Cell(1).Value;
                    menuinclude.MenuId = (int)row.Cell(2).Value;
                    menuinclude.DishId = (int)row.Cell(3).Value;
                    menuinclude.Cost = (int)row.Cell(4).Value;
                    _context.MenuIncludes.Add(menuinclude);
                }
                catch (Exception e)
                {
                    //logging самостійно :)

                }
            }
        }

        public async void DishIncludesImport(IXLWorksheet sheet)
        {
            foreach (IXLRow row in sheet.RowsUsed().Skip(1))
            {
                try
                {
                    DishInclude dishInclude = new DishInclude();
                    dishInclude.Id = (int)row.Cell(1).Value;
                    dishInclude.DishId = (int)row.Cell(2).Value;
                    dishInclude.IngredientId = (int)row.Cell(3).Value;
                    dishInclude.Mass = (int)row.Cell(4).Value;
                    _context.DishIncludes.Add(dishInclude);
                }
                catch (Exception e)
                {
                    //logging самостійно :)

                }
            }
        }


    }
}
