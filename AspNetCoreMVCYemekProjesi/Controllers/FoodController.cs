using AspNetCoreMVCYemekProjesi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMVCYemekProjesi.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;
using System.IO;

namespace AspNetCoreMVCYemekProjesi.Controllers
{
    public class FoodController : Controller
    {
        FoodRepository foodRepository = new FoodRepository();
        Context con = new Context();
        public IActionResult Index(int page=1)
        {
            return View(foodRepository.TList("Category").ToPagedList(page,5));
        }
        [HttpGet]
        public IActionResult FoodAdd()
        {
            List<SelectListItem> deger = (from x in con.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CategoryName,
                                              Value = x.CategoryID.ToString()
                                          }).ToList();
            ViewBag.dgr = deger;
            return View();
        }
        [HttpPost]
        public IActionResult FoodAdd(urunekle p)
        {
            Food f = new Food();
            if (p.FoodImageURL!=null)
            {
                var extension = Path.GetExtension(p.FoodImageURL.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/web/foodimage",newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.FoodImageURL.CopyTo(stream);
                f.FoodImageURL = newimagename;

            }
            f.FoodName = p.FoodName;
            f.FoodPrice = p.FoodPrice;
            f.FoodStock = p.FoodStock;
            f.CategoryID = p.CategoryID;
            f.FoodDescription = p.FoodDescription;
            foodRepository.TCreate(f);
            return RedirectToAction("Index");
        }
        public IActionResult FoodDelete(int id)
        {
            foodRepository.TDelete(new Food { FoodID = id });
            return RedirectToAction("Index");
        }
        public IActionResult FoodGet(int id)
        {
            List<SelectListItem> categorylist = (from i in con.Categories.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = i.CategoryName,
                                                     Value = i.CategoryID.ToString()
                                                 }).ToList();
            ViewBag.list = categorylist;
            var x = foodRepository.TGet(id);
            return View("FoodGet", x);
        }
        public IActionResult FoodUpdate(Food p)
        {
            var values = foodRepository.TGet(p.FoodID);
            values.FoodName = p.FoodName;
            values.FoodDescription = p.FoodDescription;
            values.FoodPrice = p.FoodPrice;
            values.FoodImageURL = p.FoodImageURL;
            values.FoodStock = p.FoodStock;
            values.CategoryID = p.CategoryID;
            foodRepository.TUpdate(values);
            return RedirectToAction("Index");
        }
    }
}
