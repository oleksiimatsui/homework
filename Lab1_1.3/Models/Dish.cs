using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiningRoomWA
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
        public string Name { get; set; }
        [Display(Name = "Калорії")]
        [Range(0, 4000,
        ErrorMessage = "Введіть число від 0 до 4000")]
        public int? Calories { get; set; }

        [Display(Name = "Нотатки")]
        public string? Notes { get; set; }

        [Display(Name = "Тип")]
        public int TypeId { get; set; }

        [Display(Name = "Тип")]
        public virtual Type Type { get; set; }
        public virtual ICollection<DishInclude> DishIncludes { get; set; }
        public virtual ICollection<MenuInclude> MenuIncludes { get; set; }
    }
}
