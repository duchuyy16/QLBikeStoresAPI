using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBikeStoresAPI.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLBikeStoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IXuLyTheLoaiSanPham _iXuLyTheLoai;
        public CategoryController(IXuLyTheLoaiSanPham iXuLyTheLoai)
        {
            _iXuLyTheLoai = iXuLyTheLoai;
        }
        [HttpGet("DocThongTin/{id}")]
        public CategoryModel DocThongTin(int id)
        {
            var category = _iXuLyTheLoai.DocThongTin(id);
            CategoryModel productcategory = null;
            if (category != null)
                productcategory = new CategoryModel
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName
                };
            return productcategory;
        }
    }
}
