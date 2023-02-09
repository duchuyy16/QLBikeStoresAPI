using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBikeStoresAPI.Models;
using Services.Interfaces;
using Services.Models;
using System;
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
                    Quantity=item.Quantity,
                    Product = item.Product.Adapt<ProductModel>(),
                    Store = item.Store.Adapt<StoreModel>()
                };
                liststock.Add(stock);
            }
            return liststock;
        }

        [HttpPost("ChiTiet/{productId}&{storeId}")]
        public StockModel ChiTiet(int productId, int storeId)
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

        [HttpPost("ThemKhoHang")]
        public StockModel ThemKhoHang(StockModel stock)
        {
            var newStock = new Stock
            {
                ProductId = stock.ProductId,
                StoreId = stock.StoreId,
                Quantity = stock.Quantity
            };
            var addStock = _iXuLyKhoHang.Them(newStock);
            return new StockModel
            {
                ProductId = addStock.ProductId,
                StoreId = addStock.StoreId,
                Quantity = addStock.Quantity
            };
        }

        //chi cap nhat so luong
        [HttpPost("CapNhatKho")]
        public bool CapNhatKhoHang(StockModel stock)
        {
            var updateStock = new Stock
            {
                StoreId = stock.StoreId,
                ProductId = stock.ProductId,
                Quantity = stock.Quantity
            };
            var update = _iXuLyKhoHang.Sua(updateStock);
            return update;
        }

        [HttpPost("XoaKhoHang")]
        public bool XoaKhoHang(StockModel stock)
        {
            try
            {
                var khoHang = _iXuLyKhoHang.ChiTiet(stock.ProductId,stock.StoreId);
                if (khoHang == null) return false;
                var kq = _iXuLyKhoHang.Xoa(khoHang);
                return kq;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost("TimKiem/{productId}&{storeId}")]
        public StockModel TimKiem(int productId, int storeId)
        {
            var data = _iXuLyKhoHang.Find(productId,storeId);
            StockModel stock = null;
            if (data != null)
            {
                stock = new StockModel
                {
                    StoreId = data.StoreId,
                    ProductId = data.ProductId,
                    Quantity = data.Quantity
                };
            }
            return stock;
        }

        [HttpPost("StockExists/{productId}&{storeId}")]
        public bool IsExists(int productId, int storeId)
        {
            try
            {
                var data = _iXuLyKhoHang.IsExists(productId, storeId);
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
