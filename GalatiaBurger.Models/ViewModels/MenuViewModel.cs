﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalatiaBurger.Models.ViewModels
{
    public class MenuViewModel
    {
        public Menu Menu { get; set; }

        public IEnumerable<SelectListItem>? ExtraIngredientList { get; set; } 
    }
}
