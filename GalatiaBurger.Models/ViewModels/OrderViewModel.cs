using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalatiaBurger.Models.ViewModels
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> MenuList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> SideMealList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ExtraList { get; set; }



    }
}
