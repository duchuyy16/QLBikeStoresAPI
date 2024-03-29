﻿using Mapster;
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
                    Describe = productdetails.Describe,
                    Category = productdetails.Category.Adapt<CategoryModel>(),
                    Stocks = productdetails.Stocks.Adapt<List<StockViewModel>>(),
                    Brand=productdetails.Brand.Adapt<BrandModel>(),
                };
            return product;
        }

        [HttpPost("DanhSachSanPham")]
        public List<ProductModel> DanhSachSanPham()
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
                    Category = item.Category.Adapt<CategoryModel>(),
                    Stocks = item.Stocks.Adapt<List<StockViewModel>>(),
                    Brand = item.Brand.Adapt<BrandModel>(),
                    //Category = new CategoryModel()
                    //{
                    //    CategoryId = item.Category.CategoryId,
                    //    CategoryName = item.Category.CategoryName
                    //}
                };
                listproduct.Add(productmodel);
            }

            return listproduct;
        }

        [HttpPost("DanhSachSanPhamBanChay")]
        public List<ProductModel> DanhSachSanPhamBanChay()
        {
            var product = _iXuLySanPham.DanhSachSanPhamBanChay();
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
                    Category = item.Category.Adapt<CategoryModel>(),
                    Stocks = item.Stocks.Adapt<List<StockViewModel>>(),
                    Brand = item.Brand.Adapt<BrandModel>(),
                    //Category = new CategoryModel()
                    //{
                    //    CategoryId = item.Category.CategoryId,
                    //    CategoryName = item.Category.CategoryName
                    //}
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
                    Describe = item.Describe,
                    Category = item.Category.Adapt<CategoryModel>(),
                    Stocks = item.Stocks.Adapt<List<StockViewModel>>(),
                    Brand = item.Brand.Adapt<BrandModel>(),
                };
                listproduct.Add(productmodel);
            }
            return listproduct;
        }

        [HttpPost("DocDanhSachSanPhamTheoTheLoaiThuongHieu/{categoryId}&{brandId}")]
        public List<ProductModel> DocDanhSachSanPhamTheoTheLoaiThuongHieu(int categoryId, int brandId)
        {
            var product = _iXuLySanPham.DocDanhSachSanPhamTheoTheLoaiThuongHieu(categoryId, brandId);
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
                    Category = item.Category.Adapt<CategoryModel>(),
                    Stocks = item.Stocks.Adapt<List<StockViewModel>>(),
                    Brand = item.Brand.Adapt<BrandModel>(),
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
                    Describe = item.Describe,
                    Category = item.Category.Adapt<CategoryModel>(),
                    Stocks = item.Stocks.Adapt<List<StockViewModel>>(),
                    Brand = item.Brand.Adapt<BrandModel>(),
                };
                listproduct.Add(productmodel);
            }

            return listproduct;
        }

        [HttpPost("Search")]
        public List<ProductModel> Search(string name, decimal? to, decimal? from)
        {
            var product = _iXuLySanPham.Search(name,to,from);
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
                    Category = item.Category.Adapt<CategoryModel>(),
                    Stocks = item.Stocks.Adapt<List<StockViewModel>>(),
                    Brand = item.Brand.Adapt<BrandModel>(),
                };
                listproduct.Add(productmodel);
            }

            return listproduct;
        }

        [HttpPost("ThemSanPham")]
        public ProductModel ThemSanPham(ProductModel product)
        {
            var newProduct = new Product
            {
                ProductName = product.ProductName,
                BrandId = product.BrandId,
                CategoryId = product.CategoryId,
                ModelYear = product.ModelYear,
                ListPrice = product.ListPrice,
                Describe = product.Describe,
                Discount = product.Discount,
                ImageBike = product.ImageBike,
            };
            var addSP = _iXuLySanPham.Them(newProduct);
            return new ProductModel
            {
                ProductName = addSP.ProductName,
                BrandId = addSP.BrandId,
                CategoryId = addSP.CategoryId,
                ModelYear = addSP.ModelYear,
                ListPrice = addSP.ListPrice,
                Describe = addSP.Describe,
                Discount = addSP.Discount,
                ImageBike = addSP.ImageBike,
            };
        }

        [HttpPost("CapNhatSanPham")]
        public bool CapNhatSanPham(ProductModel product)
        {
            var updateProduct = new Product
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                BrandId = product.BrandId,
                CategoryId = product.CategoryId,
                ModelYear = product.ModelYear,
                ListPrice = product.ListPrice,
                Describe = product.Describe,
                Discount = product.Discount,
                ImageBike = product.ImageBike,
            };
            var update = _iXuLySanPham.Sua(updateProduct);
            return update;
        }

        [HttpPost("XoaSanPham")]
        public bool XoaSanPham(ProductModel product)
        {
            try
            {
                var sanPham = _iXuLySanPham.ChiTietSanPham(product.ProductId);
                if (sanPham == null) return false;
                var kq = _iXuLySanPham.Xoa(sanPham);
                return kq;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost("Find/{id}")]
        public ProductModel Find(int id)
        {
            var data = _iXuLySanPham.Find(id);
            ProductModel product = null;
            if (data != null)
            {
                product = new ProductModel
                {
                    ProductId = data.ProductId,
                    ProductName = data.ProductName,
                    ListPrice = data.ListPrice,
                    BrandId = data.BrandId,
                    CategoryId = data.CategoryId,
                    Discount = data.Discount,
                    ImageBike = data.ImageBike,
                    ModelYear = data.ModelYear,
                    Describe = data.Describe
                };
            }
            return product;
        }

        [HttpPost("ProductExists/{id}")]
        public bool IsExists(int id)
        {
            try
            {
                var data = _iXuLySanPham.IsExists(id);
                if (data != true) return false;
                else return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
