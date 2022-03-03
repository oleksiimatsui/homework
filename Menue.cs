using System;
using System.Collections.Generic;

namespace DiningRoomWebApplication
{
    public partial class Menue
    {
        public Menue()
        {
            MenuIncludes = new HashSet<MenuInclude>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<MenuInclude> MenuIncludes { get; set; }
    }
}
