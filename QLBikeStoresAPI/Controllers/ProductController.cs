using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLBikeStoresAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace QLBikeStoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly demoContext _context;
        public ProductController(demoContext context)
        {
            _context = context;
        }

        [HttpGet("DanhSachSanPham")]
        public List<Product> ListProduct()
        {
            var products = _context.Products.Include(p => p.Category).Include(m => m.Stocks).ToList();
            return products;
        }


        [HttpGet("DanhSachSanPhamTheoTheLoai/{categoryId}")]
        public List<Product> ListCategory(int categoryId)
        {
            var products = _context.Products.Where(x => x.CategoryId == categoryId).Include(p => p.Category).Include(m => m.Stocks).ToList();
            return products;
        }
    }
}
