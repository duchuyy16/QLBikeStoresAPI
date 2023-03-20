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
            var products= _context.Products.Include(p => p.Brand).Include(p => p.Category).Include(m => m.Stocks).ToList();
            return products;
        }
        public List<Product> DanhSachSanPhamBanChay()
        {
            var products = _context.Products.Include(p => p.Brand).Include(p => p.Category).Include(m => m.Stocks)
                .OrderByDescending(l => l.ListPrice)
                .Take(10)
                .ToList();
            return products;
        }
        public List<Product> DocDanhSachSanPhamTheoTheLoai(int categoryId)
        {
            var products = _context.Products.Where(x => x.CategoryId == categoryId).Include(p => p.Category).Include(p => p.Brand).Include(m => m.Stocks).ToList();
            return products;
        }

        public List<Product> DocDanhSachSanPhamTheoTheLoaiThuongHieu(int categoryId, int brandId)
        {
            var products = _context.Products.Where(x => x.CategoryId == categoryId && x.BrandId == brandId).Include(p => p.Brand).Include(p => p.Category).Include(m => m.Stocks).ToList();
            return products;
        }

        public Product ChiTietSanPham(int id)
        {
            var products = _context.Products.Include(p => p.Category).Include(m => m.Brand).Include(m => m.Stocks).SingleOrDefault(p => p.ProductId == id);
            return products;
        }

        public List<Product> TimKiem(string name)
        {
            var products = _context.Products.Where(m => m.ProductName.Contains(name)).Include(p => p.Brand).Include(p => p.Category).Include(m => m.Stocks).ToList();
            return products;
        }

        public Product Find(int id)
        {
            return _context.Products.Find(id);
        }

        public bool IsExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

        public List<Product> Search(string name, decimal? to, decimal? from)
        {
            var products = from product in _context.Products.Include(p => p.Brand).Include(p => p.Category) select product;
            //var pagedList =  products.ToPagedList((int)pageNo, 10);
            if (!string.IsNullOrEmpty(name))//neu ma khong trong
            {
                if (to != null && from != null)
                {
                    products = products.Where(x => x.ProductName.Contains(name) && x.ListPrice >= to && x.ListPrice <= from).OrderByDescending(l => l.ListPrice);
                }
                else
                {
                    products = products.Where(x => x.ProductName.Contains(name));

                }
            }
            else
            {
                if (to != null && from != null)
                {
                    products = products.Where(x => x.ProductName.Contains(name) && x.ListPrice >= to && x.ListPrice <= from);
                }
            }
            return products.ToList();
        }

        
    }
}
