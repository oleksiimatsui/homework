using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiningRoomWA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartDishCalsController : ControllerBase
    {
        private readonly DiningRoomDBContext _context;
        public ChartDishCalsController(DiningRoomDBContext context)
        {
            _context = context;
        }

        [HttpGet("JsonData")]
        public JsonResult JsonData()
        {
            var dishes = _context.Dishes.ToList();
            List<object> dishCalories = new List<Object>();
            dishCalories.Add(new[] { "Страва", "Кількість калорій" });
            foreach (var d in dishes)
            {
                dishCalories.Add(new object[] { d.Name, d.Calories });
            }
            return new JsonResult(dishCalories);
        }
    }
}
