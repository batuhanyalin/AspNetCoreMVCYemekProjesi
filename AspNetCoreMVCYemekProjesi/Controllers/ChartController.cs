using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMVCYemekProjesi.Data;
using AspNetCoreMVCYemekProjesi.Repositories;
using AspNetCoreMVCYemekProjesi.Data.Models;

namespace AspNetCoreMVCYemekProjesi.Controllers
{
    public class ChartController : Controller
    {
        Context con = new Context();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }
        public List<ClassChart> ProList()
        {
            List<ClassChart> cs = new List<ClassChart>();
            cs.Add(new ClassChart()
            {
                proname = "Computer",
                stock = 150
            });
            cs.Add(new ClassChart()
            {
                proname = "LCD",
                stock = 30
            });
            cs.Add(new ClassChart()
            {
                proname = "USB Disk",
                stock = 175
            });
            return cs;
        }
        public IActionResult Statistics()
        {
            var totalfood = con.Foods.Count();
            ViewBag.totalfood = totalfood;
            var totalcategory = con.Categories.Count();
            ViewBag.totalcategory = totalcategory;

            var foodid = con.Categories.Where(x => x.CategoryName == "Meyveler").Select(y => y.CategoryID).FirstOrDefault();
            var totalfruit = con.Foods.Where(m => m.CategoryID == foodid).Count();
            ViewBag.totalfruit = totalfruit;

            var vegetableid = con.Categories.Where(x => x.CategoryName == "Sebzeler").Select(y => y.CategoryID).FirstOrDefault();
            var totalvegetable = con.Foods.Where(m => m.CategoryID == vegetableid).Count();

            ViewBag.totalvegetable = totalvegetable;

            var sumfood = con.Foods.Sum(x => x.FoodStock);
            ViewBag.sumfood = sumfood;


            var totallegumes = con.Foods.Where(x => x.CategoryID == con.Categories.Where(y => y.CategoryName == "Baklagiller").Select(z => z.CategoryID).FirstOrDefault()).Count();
            ViewBag.totallegumes = totallegumes;

            var maxstockfood = con.Foods.OrderByDescending(x => x.FoodStock).Select(y => y.FoodName).FirstOrDefault();
            ViewBag.maxstockfood = maxstockfood;

            var minstockfood = con.Foods.OrderBy(x => x.FoodStock).Select(y => y.FoodName).FirstOrDefault();
            ViewBag.minstockfood = minstockfood;

            var foodpriceavg = con.Foods.Average(x => x.FoodPrice).ToString("0.00");
            ViewBag.foodpriceavg = foodpriceavg;

            var totalfruitstock = con.Foods.Where(y => y.CategoryID == foodid).Sum(x => x.FoodStock);
            ViewBag.totalfruitstock = totalfruitstock;

            var totalvegetablestock = con.Foods.Where(x => x.CategoryID == vegetableid).Sum(y => y.FoodStock);
            ViewBag.totalvegetablestock = totalvegetablestock;

            var mostexpensiveitem = con.Foods.OrderByDescending(x => x.FoodPrice).Select(y=>y.FoodName).FirstOrDefault();
            ViewBag.mostexpensiveitem = mostexpensiveitem;


            return View();
        }
    }
}
