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
        //Include(p=>p.Category).Include(m=>m.Stocks).OrderBy(l=>l.ListPrice)
        public List<Product> DocDanhSachSanPhamTheoTheLoai(int categoryId)
        {
            throw new NotImplementedException();
        }

        public List<Product> DocDanhSachSanPhamTheoTheLoaiThuongHieu(int categoryId)
        {
            throw new NotImplementedException();
        }

        
    }
}
