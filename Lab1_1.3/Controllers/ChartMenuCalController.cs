using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiningRoomWA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartMenuCalController : ControllerBase
    {
        private readonly DiningRoomDBContext _context;
        public ChartMenuCalController(DiningRoomDBContext context)
        {
            _context = context;
        }


        [HttpGet("JsonData")]
        public JsonResult JsonData()
        {
            var list = _context.MenuIncludes.GroupBy(m => m.MenuId).Select(m => new { Id = m.Key, Count = m.Count() });

            var res = from m in _context.Menus
                      join l in list
                      on m.Id equals l.Id
                      select new { Name = m.Name, Count = l.Count };


            List<object> menucals = new List<Object>();

            menucals.Add(new[] { "Меню", "Кількість страв" });
            foreach (var m in res)
            {
                menucals.Add(new object[] { m.Name, m.Count });
            }
            return new JsonResult(menucals);

        }
    }
}