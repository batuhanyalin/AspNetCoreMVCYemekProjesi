using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMVCYemekProjesi.Repositories;

namespace AspNetCoreMVCYemekProjesi.ViewComponents
{
    public class FoodListByCategory:ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            FoodRepository foodRepository = new FoodRepository();
            var foodlist = foodRepository.List(x=>x.CategoryID==id);
            return View(foodlist);
        }
    }
}
