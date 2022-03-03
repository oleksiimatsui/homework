using System;
using System.Collections.Generic;

namespace DiningRoomWebApplication
{
    public partial class MenuInclude
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public int DishId { get; set; }
        public double? Cost { get; set; }

        public virtual Dish Dish { get; set; } = null!;
        public virtual Menue Menu { get; set; } = null!;
    }
}
