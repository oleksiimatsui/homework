using System;
using System.Collections.Generic;

namespace DiningRoomWebApplication
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            DishIncludes = new HashSet<DishInclude>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<DishInclude> DishIncludes { get; set; }
    }
}
