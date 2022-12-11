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
    public class XuLySanPham:BaseRepository<Product>,IXuLySanPham
    {
        public XuLySanPham(demoContext context):base(context) { }
        public List<Product> DocDanhSachSanPham()
        {
                var products=_context.Products.ToList();
                return products;
        }
        
        public List<Product> DocDanhSachSanPhamTheoTheLoai(int categoryId)
        {
            var products = _context.Products.Where(x => x.CategoryId == categoryId).Include(p => p.Category).ToList();
            return products;
        }

        public List<Product> DocDanhSachSanPhamTheoTheLoaiThuongHieu(int categoryId, int brandId)
        {
            var products = _context.Products.Where(x => x.CategoryId == categoryId && x.BrandId == brandId).Include(p => p.Category).ToList();
            return products;
        }

        
    }
}
