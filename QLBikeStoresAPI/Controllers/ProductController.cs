using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLBikeStoresAPI.Models;
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
        private readonly XyLySanPham _iXuLySanPham;
        public ProductController(XyLySanPham iXuLySanPham)
        {
            _iXuLySanPham = iXuLySanPham;
        }

        //[HttpGet("DocThongTinSanPham")]
        //public ProductModel DocThongTinSanPham()
        //{
        //    var product = _iXuLySanPham.DocDanhSachSanPham();
        //    ProductModel productmodel = null;
        //    if(productmodel!=null)
        //    {
        //        productmodel=new ProductModel
        //        {
        //            ProductId=product.ProductId,
        //            ProductName=product.ProductName,
        //        }
        //    }
        //}
    }
}
