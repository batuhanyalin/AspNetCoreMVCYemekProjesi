using AspNetCoreMVCYemekProjesi.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMVCYemekProjesi.Repositories;

namespace AspNetCoreMVCYemekProjesi.Controllers
{
    public class HomeController : Controller
    {
        Context con = new Context();
        CategoryRepository categoryRepository = new CategoryRepository();
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult CategoryDetails(int id)
        {
            ViewBag.x = id;
            return View();
        }
    }
}
