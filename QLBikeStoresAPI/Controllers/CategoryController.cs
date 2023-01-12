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
        [HttpPost("DocThongTin/{id}")]
        public CategoryModel DocThongTin(int id)
        {
            var category = _iXuLyTheLoai.DocThongTin(id);
            //var category = _iXuLyTheLoai.DocTheoDieuKien(x => x.Id.Equals(id)).FirstOrDefault();

            CategoryModel productcategory = null;
            if (category != null)
                productcategory = new CategoryModel
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName
                };
            return productcategory;
        }

        [HttpPost("DanhSachTheLoai")]
        public List<CategoryModel> DanhSachTheLoai()
        {
            var categories = _iXuLyTheLoai.DanhSachTheLoai();
            //var category = _iXuLyTheLoai.DocTheoDieuKien(x => x.Id.Equals(id)).FirstOrDefault();
            List<CategoryModel> listcategory = new List<CategoryModel>();
            foreach (var item in categories)
            {
                CategoryModel category = new CategoryModel
                {
                    CategoryId = item.CategoryId,
                    CategoryName = item.CategoryName
                };
                listcategory.Add(category);
            }
            return listcategory;
        }

    }
}
