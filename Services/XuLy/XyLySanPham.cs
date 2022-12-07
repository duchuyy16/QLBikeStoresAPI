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
    public class XyLySanPham:BaseRepository<Product>,IXuLySanPham
    {
        public XyLySanPham(demoContext context):base(context) { }
        public List<Product> DocDanhSachSanPham()
        {
            try
            {
                var products=_context.Products.Include(p=>p.Category).Include(m=>m.Stocks).OrderBy(l=>l.ListPrice);
                return products.ToList();
            }
            catch(Exception)
            {
                return null;
            }
        }

        public Product DocDanhSachSanPhamTheoTheLoai(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Product DocDanhSachSanPhamTheoTheLoaiThuongHieu(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
