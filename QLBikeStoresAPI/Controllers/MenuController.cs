using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBikeStoresAPI.Models;
using Services.Interfaces;
using Services.Models;
using System.Collections.Generic;

namespace QLBikeStoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IXuLyMenu _iXuLyMenu;
        public MenuController(IXuLyMenu iXuLyMenu)
        {
            _iXuLyMenu = iXuLyMenu;
        }

        [HttpPost("GetMenuList")]
        public List<MenuViewModel> GetMenuList()
        {
            var menuModel = _iXuLyMenu.GetAll();
            List<MenuViewModel> listMenu = new List<MenuViewModel>();
            foreach (var item in menuModel)
            {
                MenuViewModel menu = new MenuViewModel
                {
                    Brands = item.Brands,
                    CategoryId = item.CategoryId,
                    CategoryName = item.CategoryName,
                };
                listMenu.Add(menu);
            }

            return listMenu;
        }
    }
}
