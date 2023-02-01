using Microsoft.EntityFrameworkCore;
using Services.Base;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.XuLy
{
    public class XuLyMenu : BaseRepository<MenuModel>, IXuLyMenu
    {
        public XuLyMenu(demoContext context) : base(context)
        {
        }

        public List<MenuModel> GetAll()
        {
            List<Category> categories = _context.Categories.ToList();
            List<MenuModel> menuList = new List<MenuModel>();
            foreach (var category in categories)
            {
                MenuModel menu = new MenuModel
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    Brands = _context.Brands.Include(x => x.Products).Where(n => n.Products.Any(m => m.CategoryId == category.CategoryId)).ToList()
                };
                menuList.Add(menu);
            }
            return menuList;
        }
    }
}
