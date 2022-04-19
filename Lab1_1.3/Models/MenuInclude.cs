using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiningRoomWA
{
    public partial class MenuInclude
    {
        public int Id { get; set; }
        public int MenuId { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Страва")]
        public int DishId { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Вартість")]
        [Range(0, Double.MaxValue, ErrorMessage = "Поле {0} має бути більше ніж {1}.")]
        public double? Cost { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Страва")]
        public virtual Dish Dish { get; set; } = null!;
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Меню")]
        public virtual Menu Menu { get; set; } = null!;
    }
}
