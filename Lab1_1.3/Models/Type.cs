using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DiningRoomWebApplication
{
    public partial class Type
    {
        public Type()
        {
            Dishes = new HashSet<Dish>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Тип")]
        public string? Name { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
