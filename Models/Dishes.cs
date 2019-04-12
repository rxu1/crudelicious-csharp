using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class Dishes
    {
      [Key]

      public int DishId { get; set; }

      [Required]
      [Display(Name = "Name of Dish:")]
      public string Name { get; set; }

      [Required]
      [Display(Name = "Chef's Name: ")]
      public string Chef { get; set; }

      [Required]
      [Display(Name = "Tastiness:")]
      [Range(1,5, ErrorMessage="Tastiness must be between 1-5!")]
      public int Tastiness { get; set; }

      [Required]
      [Display(Name = "Number of calories: ")]
      [Range(0, 10000, ErrorMessage="The entered calorie count isn't valid!" )]
      public int Calories { get; set; }

      [Required]
      [Display(Name = "Description: ")]
      [MinLength(2, ErrorMessage="Description must be longer than 2 characters!")]
      public string Description { get; set; }

      public DateTime CreatedAt { get; set; } = DateTime.Now; 
      public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}