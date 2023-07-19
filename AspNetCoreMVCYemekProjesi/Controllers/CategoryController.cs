using AspNetCoreMVCYemekProjesi.Data.Models;
using AspNetCoreMVCYemekProjesi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace AspNetCoreMVCYemekProjesi.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
       
        public IActionResult Index(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(categoryRepository.List(x=>x.CategoryName==p));
            }
            return View(categoryRepository.TList());
        }
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryAdd");
            }
            categoryRepository.TCreate(p);
            return RedirectToAction("Index");
        }
        public IActionResult CategoryGet(int id)
        {
            var x = categoryRepository.TGet(id);

            return View("CategoryGet", x);
        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category p)
        {
            var values = categoryRepository.TGet(p.CategoryID);
            values.CategoryName = p.CategoryName;
            values.CategoryDescription = p.CategoryDescription;
            values.CategoryStatus = p.CategoryStatus;
            categoryRepository.TUpdate(values);
            return RedirectToAction("Index");
        }
        public IActionResult CategoryDelete(int id)
        {
            var values = categoryRepository.TGet(id);
            values.CategoryStatus = false;
            categoryRepository.TUpdate(values);
            return RedirectToAction("Index");
        }
    }
}
