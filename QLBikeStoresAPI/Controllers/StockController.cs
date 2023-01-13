using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBikeStoresAPI.Models;
using Services.Interfaces;
using System.Collections.Generic;

namespace QLBikeStoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IXuLyKhoHang _iXuLyKhoHang;
        public StockController(IXuLyKhoHang iXuLyKhoHang)
        {
            _iXuLyKhoHang = iXuLyKhoHang;
        }

        [HttpPost("DocDanhSach")]
        public List<StockModel> DocDanhSach()
        {

            var stocks = _iXuLyKhoHang.DocDanhSach();
            List<StockModel> liststock = new List<StockModel>();
            foreach (var item in stocks)
            {
                StockModel stock = new StockModel
                {
                    StoreId = item.StoreId,
                    ProductId = item.ProductId,
                    Quantity=item.Quantity
                };
                liststock.Add(stock);
            }
            return liststock;
        }

        [HttpPost("ChiTiet/{productId}&{storeId}")]
        public StockModel ChiTietDonDatHang(int productId, int storeId)
        {
            var stockdetails = _iXuLyKhoHang.ChiTiet(productId, storeId);
            StockModel stock = null;
            if (stockdetails != null)
            {
                stock = new StockModel
                {
                    ProductId = stockdetails.ProductId,
                    StoreId = stockdetails.StoreId,
                    Quantity = stockdetails.Quantity
                };
            }
            return stock;
        }
    }
}
