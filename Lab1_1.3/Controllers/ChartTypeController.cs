using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiningRoomWA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartTypeController : ControllerBase
    {
        private readonly DiningRoomDBContext _context;
        public ChartTypeController(DiningRoomDBContext context)
        {
            _context = context;
        }

        [HttpGet("JsonData")]
        public JsonResult JsonData()
        {
            var types = _context.Types.ToList();
            List<object> typesDish = new List<Object>();
            typesDish.Add(new[] { "Тип", "Кількість страв" });
            foreach (var t in types)
            {

                var    dishes = (from dish in _context.Dishes
                                 where dish.TypeId == t.Id
                                 select dish).ToList();

                typesDish.Add(new object[] { t.Name, dishes.Count() });
            }
            return new JsonResult(typesDish);
        }
    }
}
