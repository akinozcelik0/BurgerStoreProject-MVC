using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalatiaBurger.Models
{
    public class SideMeal
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, 1000)]
        public double Price { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }

    }
}
