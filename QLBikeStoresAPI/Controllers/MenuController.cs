﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBikeStoresAPI.Models;

namespace QLBikeStoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        

        //[HttpPost("GetMenuList")]
        //public MenuModel GetMenuList()
        //{
        //    List<Category> categories = _context.Categories.ToList();
        //    List<MenuViewModel> menuList = new List<MenuViewModel>();
        //    foreach (var category in categories)
        //    {
        //        MenuViewModel menu = new MenuViewModel
        //        {
        //            CategoryId = category.CategoryId,
        //            CategoryName = category.CategoryName,
        //            Brands = _context.Brands.Include(x => x.Products).Where(n => n.Products.Any(m => m.CategoryId == category.CategoryId)).ToList()
        //        };
        //        menuList.Add(menu);
        //    }
        //    return stock;
        //}
    }
}