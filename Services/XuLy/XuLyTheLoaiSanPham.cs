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
    public class XuLyTheLoaiSanPham:BaseRepository<Category>,IXuLyTheLoaiSanPham
    {
        public XuLyTheLoaiSanPham(demoContext context) : base(context) { }
        public Category DocThongTin(int id)
        {
            if (id <= 0)
                return null;
            var categories = _context.Categories.FirstOrDefault(x => x.CategoryId.Equals(id));
            return categories;
        }

        public new bool Xoa(Category entity)
        {
            try
            {
                var categoryid = entity.CategoryId;
                var product = _context.Products.FirstOrDefault(x => x.CategoryId.Equals(categoryid));
                if (product != null) return false;
                var result = base.Xoa(entity);
                return result;

            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
