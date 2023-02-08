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
    public class XuLyNhanHieu : BaseRepository<Brand>, IXuLyNhanHieu
    {
        public XuLyNhanHieu(demoContext context) : base(context){}

        public bool BrandExists(int id)
        {
            return _context.Brands.Any(e => e.BrandId == id);
        }

        public Brand ChiTietNhanHieu(int id)
        {
            var brands = _context.Brands.FirstOrDefault(b=>b.BrandId.Equals(id));
            return brands;
        }

        public List<Brand> DanhSachNhanHieu()
        {
            var brands = _context.Brands.ToList();
            return brands;
        }

        public List<Brand> DanhSachNhanHieuTheoDieuKien(int category)
        {
            var brands = _context.Brands.Include(x => x.Products).Where(n => n.Products.Any(m => m.CategoryId == category)).ToList();
            return brands;
        }

        public Brand Find(int id)
        {
            return _context.Brands.Find(id);
        }

        
    }
}
