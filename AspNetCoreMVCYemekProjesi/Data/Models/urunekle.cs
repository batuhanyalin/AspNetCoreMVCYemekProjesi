using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMVCYemekProjesi.Data.Models
{
    public class urunekle
    {
        public string FoodName { get; set; }
        public string FoodDescription { get; set; }
        public double FoodPrice { get; set; }
        public IFormFile FoodImageURL { get; set; }
        public int FoodStock { get; set; }
        public int CategoryID { get; set; }
    }
}
