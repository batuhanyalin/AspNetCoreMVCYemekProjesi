using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMVCYemekProjesi.Data.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Category name cannot be empty.")]
        [StringLength(20, ErrorMessage = "You must use the least 4 and the most 20 lenght characters.", MinimumLength = 4)]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Category description cannot be empty.")]
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; } = true;

        public List<Food> Foods { get; set; }
    }
}
