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

        [HttpGet("DocDanhSachSanPham")]
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
                    };
                    listproduct.Add(productmodel);
                }
                                           
            return listproduct;
        }
    }
}
