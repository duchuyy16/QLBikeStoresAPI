using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLBikeStoresAPI.Models;
using Services.Interfaces;
using Services.Models;
using Services.XuLy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLBikeStoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IXuLySanPham _iXuLySanPham;
        public ProductController(IXuLySanPham iXuLySanPham)
        {
            _iXuLySanPham = iXuLySanPham;
        }

        [HttpPost("ChiTietSanPham/{id}")]
        public ProductModel ChiTietSanPham(int id)
        {
            var productdetails = _iXuLySanPham.ChiTietSanPham(id);
            ProductModel product = null;
            if (productdetails != null)
                product = new ProductModel
                {
                    ProductId = productdetails.ProductId,
                    ProductName = productdetails.ProductName,
                    ListPrice = productdetails.ListPrice,
                    BrandId = productdetails.BrandId,
                    CategoryId = productdetails.CategoryId,
                    Discount = productdetails.Discount,
                    ImageBike = productdetails.ImageBike,
                    ModelYear = productdetails.ModelYear,
                    Describe=productdetails.Describe,
                };
            return product;
        }

        [HttpPost("DocDanhSachSanPham")]
        public List<ProductModel> DocDanhSachSanPham()
        {
            var product = _iXuLySanPham.DocDanhSachSanPham();
            List<ProductModel> listproduct = new List<ProductModel>(); 
            
                foreach (var item in product)
                {
                    ProductModel productmodel = new ProductModel
                    {
                        ProductId = item.ProductId,
                        ProductName = item.ProductName,
                        ListPrice = item.ListPrice,
                        BrandId = item.BrandId,
                        CategoryId = item.CategoryId,
                        Discount = item.Discount,
                        ImageBike = item.ImageBike,
                        ModelYear = item.ModelYear,
                        Describe = item.Describe,
                    };
                    listproduct.Add(productmodel);
                }
                                           
            return listproduct;
        }

        [HttpPost("DocDanhSachSanPhamTheoTheLoai/{categoryId}")]
        public List<ProductModel> DocDanhSachSanPhamTheoTheLoai(int categoryId)
        {
            var product = _iXuLySanPham.DocDanhSachSanPhamTheoTheLoai(categoryId);
            List<ProductModel> listproduct = new List<ProductModel>();

            foreach (var item in product)
            {
                ProductModel productmodel = new ProductModel
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    ListPrice = item.ListPrice,
                    BrandId = item.BrandId,
                    CategoryId = item.CategoryId,
                    Discount = item.Discount,
                    ImageBike = item.ImageBike,
                    ModelYear = item.ModelYear,
                    Describe=item.Describe,
                };
                listproduct.Add(productmodel);
            }

            return listproduct;
        }

        [HttpPost("DocDanhSachSanPhamTheoTheLoaiThuongHieu/{categoryId}&{brandId}")]
        public List<ProductModel> DocDanhSachSanPhamTheoTheLoaiThuongHieu(int categoryId, int brandId)
        {
            var product = _iXuLySanPham.DocDanhSachSanPhamTheoTheLoaiThuongHieu(categoryId,brandId);
            List<ProductModel> listproduct = new List<ProductModel>();

            foreach (var item in product)
            {
                ProductModel productmodel = new ProductModel
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    ListPrice = item.ListPrice,
                    BrandId = item.BrandId,
                    CategoryId = item.CategoryId,
                    Discount = item.Discount,
                    ImageBike = item.ImageBike,
                    ModelYear = item.ModelYear,
                    Describe = item.Describe,
                };
                listproduct.Add(productmodel);
            }
            return listproduct;
        }


        [HttpPost("TimKiem/{name}")]
        public List<ProductModel> TimKiem(string name)
        {
            var product = _iXuLySanPham.TimKiem(name);
            List<ProductModel> listproduct = new List<ProductModel>();

            foreach (var item in product)
            {
                ProductModel productmodel = new ProductModel
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    ListPrice = item.ListPrice,
                    BrandId = item.BrandId,
                    CategoryId = item.CategoryId,
                    Discount = item.Discount,
                    ImageBike = item.ImageBike,
                    ModelYear = item.ModelYear,
                    Describe=item.Describe,
                };
                listproduct.Add(productmodel);
            }

            return listproduct;
        }

        [HttpPost("Themsanpham")]
        public async Task<IActionResult> ThemSanPham(Product product)
        {
            try
            {
                var id =await _iXuLySanPham.ThemSanPham(Product);
                var productdetails = await _iXuLySanPham.GetProduct(id);
                return productdetails ==  null? NotFound() : Ok(productdetails);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _iXuLySanPham.GetProduct(id);
            return product == null ? NotFound() : Ok(product);          
        }
    }
}
