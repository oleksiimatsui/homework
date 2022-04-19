using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiningRoomWA
{
    public partial class Menu
    {
        public Menu()
        {
            MenuIncludes = new HashSet<MenuInclude>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Меню")]
        public string? Name { get; set; }

        public virtual ICollection<MenuInclude> MenuIncludes { get; set; }
    }
}
