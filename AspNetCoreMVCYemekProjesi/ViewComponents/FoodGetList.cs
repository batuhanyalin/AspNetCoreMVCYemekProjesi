using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMVCYemekProjesi.Repositories;

namespace AspNetCoreMVCYemekProjesi.ViewComponents
{
    public class FoodGetList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            FoodRepository foodRepository = new FoodRepository();
            var foodlist = foodRepository.TList();
            return View(foodlist);
        }
    }
}
