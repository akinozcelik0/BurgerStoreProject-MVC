using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalatiaBurger.Models.ViewModels
{
    public class MenuSideMealExtraVM
    {
        public IEnumerable<Menu> Menus { get; set; }
        public IEnumerable<ExtraIngredient> ExtraIngredients { get; set; }
        public IEnumerable<SideMeal> SideMeals { get; set; }







    }
}
