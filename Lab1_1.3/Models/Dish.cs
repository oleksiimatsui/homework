using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


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
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Страва")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public double? Calories { get; set; }
        public string? Notes { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public int? TypeId { get; set; }

        public virtual Type? Type { get; set; }
        public virtual ICollection<DishInclude> DishIncludes { get; set; }
        public virtual ICollection<MenuInclude> MenuIncludes { get; set; }
    }
}
