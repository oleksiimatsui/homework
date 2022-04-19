using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiningRoomWA
{
    public partial class DishInclude
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Страва")]
        public int? DishId { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Інгредієнт")]
        public int? IngredientId { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Маса")]
        [Range(0, 4000,
        ErrorMessage = "Введіть число від 0 до 4000")]
        public double Mass { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Страва")]
        public virtual Dish? Dish { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Інгредієнт")]
        public virtual Ingredient? Ingredient { get; set; }
    }
}
