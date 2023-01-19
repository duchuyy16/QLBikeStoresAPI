using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBikeStoresAPI.Models;
using Services.Interfaces;
using Services.Models;
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
        [HttpPost("ThemTheLoai")]
        public CategoryModel ThemTheLoai(CategoryModel category)
        {
            var newCategory = new Category
            {
                CategoryName = category.CategoryName
            };
            var addCategory = _iXuLyTheLoai.Them(newCategory);
            return new CategoryModel
            {
                CategoryName = addCategory.CategoryName
            };
        }

        [HttpPost("CapNhatTheLoai")]
        public bool CapNhatTheLoai(CategoryModel category)
        {
            var updateCategory = new Category
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
            var update = _iXuLyTheLoai.Sua(updateCategory);
            return update;
        }

        [HttpPost("XoaTheLoai")]
        public bool XoaTheLoai(CategoryModel category)
        {
            try
            {
                var theLoai = _iXuLyTheLoai.DocThongTin(category.CategoryId);
                if (theLoai == null) return false;
                var kq = _iXuLyTheLoai.Xoa(theLoai);
                return kq;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
