using System;
using System.Collections.Generic;

namespace DiningRoomWebApplication
{
    public partial class Dish
    {
        public Dish()
        {
            DishIncludes = new HashSet<DishInclude>();
            MenuIncludes = new HashSet<MenuInclude>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public double? Calories { get; set; }
        public string? Notes { get; set; }
        public int? TypeId { get; set; }

        public virtual Type? Type { get; set; }
        public virtual ICollection<DishInclude> DishIncludes { get; set; }
        public virtual ICollection<MenuInclude> MenuIncludes { get; set; }
    }
}
