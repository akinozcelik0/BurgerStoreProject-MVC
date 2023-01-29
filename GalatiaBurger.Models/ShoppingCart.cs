using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalatiaBurger.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public int? MenuId { get; set; }

        [ForeignKey("MenuId")]
        [ValidateNever]
        public Menu? Menu { get; set; }


        public int? ExtraIngredientId { get; set; }

        [ForeignKey("ExtraIngredientId")]
        [ValidateNever]
        public ExtraIngredient? ExtraIngredient { get; set; }


        public int? SideMealId { get; set; }

        [ForeignKey("SideMealId")]
        [ValidateNever]
        public SideMeal? SideMeal { get; set; }

        //Null Ref
        public string? Size { get; set; }


        [Range(1, 1000, ErrorMessage = "Please enter a value between 1 and 1000")]
        public int Count { get; set; }

        [NotMapped]
        public double Price { get; set; }
    }
}
