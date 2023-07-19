using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMVCYemekProjesi.Data.Models
{
    public class Food
    {
        [Key]
        public int FoodID { get; set; }
        public string FoodName { get; set; }
        public string FoodDescription { get; set; }
        public double FoodPrice { get; set; }
        public string FoodImageURL { get; set; }
        public int FoodStock { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
