using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiningRoomWA
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            DishIncludes = new HashSet<DishInclude>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Інгредієнт")]
        public string Name { get; set; } = null!;

        public virtual ICollection<DishInclude> DishIncludes { get; set; }
    }
}
