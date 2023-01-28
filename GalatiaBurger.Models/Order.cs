using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalatiaBurger.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        public double OrderNo { get; set; }
        public Order()
        {
            var rnd = new Random();
            var generatedNumbers = new HashSet<long>();
            while (true)
            {
                long orderNumber = (long)(rnd.NextDouble() * 10000000000000);
                if (!generatedNumbers.Contains(orderNumber))
                {
                    generatedNumbers.Add(orderNumber);
                    OrderNo = orderNumber;
                    break;
                }
            }

        }

        [Required]
        public string Size { get; set; }

        [Required]
        [Range(1, 100)]
        public int Count { get; set; }

        [Required]
        [Display(Name = "Menu")]
        public int MenuId { get; set; }

        [Required]
        [Display(Name = "Extra Ingredient")]
        public int ExtraIngredientId { get; set; }

        [Required]
        [Display(Name = "Side Meal")]
        public int SideMealId { get; set; }

        //Navigation Property
        [ForeignKey("MenuId")]
        [ValidateNever]
        public Menu Menu { get; set; }

        [ValidateNever]
        public ExtraIngredient ExtraIngredient { get; set; }


        [ValidateNever]
        public SideMeal SideMeal { get; set; }






    }
}
