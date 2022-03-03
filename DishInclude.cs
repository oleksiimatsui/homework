using System;
using System.Collections.Generic;

namespace DiningRoomWebApplication
{
    public partial class DishInclude
    {
        public int Id { get; set; }
        public int? DishId { get; set; }
        public int? IngredientId { get; set; }
        public double? Mass { get; set; }

        public virtual Dish? Dish { get; set; }
        public virtual Ingredient? Ingredient { get; set; }
    }
}
