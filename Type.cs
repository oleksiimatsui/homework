using System;
using System.Collections.Generic;

namespace DiningRoomWebApplication
{
    public partial class Type
    {
        public Type()
        {
            Dishes = new HashSet<Dish>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
