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
    public class OrderItemController : ControllerBase
    {
        public readonly IXuLyDonDatHang _iXuLyDonDatHang;
        public readonly IXuLySanPham _xuLySanPham;

        public OrderItemController(IXuLyDonDatHang iXuLyDonDatHang, IXuLySanPham xuLySanPham)
        {
            _iXuLyDonDatHang = iXuLyDonDatHang;
            _xuLySanPham = xuLySanPham; 
        }
        [HttpPost("DanhSachDonDatHang")]
        public List<OrderItemModel> DanhSachDonDatHang()
        {
            var orderItems = _iXuLyDonDatHang.DanhSachDonDatHang();
            List<OrderItemModel> listOrders = new List<OrderItemModel>();
            foreach (var item in orderItems)
            {
                OrderItemModel orderItem = new OrderItemModel
                {
                    OrderId = item.OrderId,
                    ItemId = item.ItemId,
                    ProductId = item.ProductId,
                    ListPrice = item.ListPrice,
                    Discount = item.Discount,
                    Quantity = item.Quantity,
                    Product = item.Product.Adapt<ProductStockModel>(),
                    Order=item.Order.Adapt<OrderViewModel>(),
                    
                };
                listOrders.Add(orderItem);
            }
            return listOrders;
        }

        [HttpPost("ChiTietDonDatHang/{orderId}&{itemId}")]
        public OrderItemModel ChiTietDonDatHang(int orderId, int itemId)
        {
            var orderDetails = _iXuLyDonDatHang.ChiTietDonDatHang(orderId, itemId);
            OrderItemModel orderitem = null;
            if (orderDetails != null)
            {
                orderitem = new OrderItemModel
                {
                    OrderId = orderDetails.OrderId,
                    ItemId = orderDetails.ItemId,
                    ProductId = orderDetails.ProductId,
                    ListPrice = orderDetails.ListPrice,
                    Discount = orderDetails.Discount,
                    Quantity = orderDetails.Quantity
                };
            }
            return orderitem;
        }


        [HttpPost("ThemChiTietDonDatHang")]
        public OrderItemModel ThemChiTietDonDatHang(OrderItemModel orderItem)
        {
            var product = _xuLySanPham.ChiTietSanPham(orderItem.ProductId);
            var orderId = _iXuLyDonDatHang.FindMaxId();

            var newOrderItem = new OrderItem
            {
                OrderId = orderId + 1,
                ItemId = orderItem.ItemId,
                ProductId = orderItem.ProductId,
                ListPrice = orderItem.ListPrice,
                Discount = product.Discount,
                Quantity = orderItem.Quantity
            };

            var addOrderItem = _iXuLyDonDatHang.Them(newOrderItem);

            if (addOrderItem == null)
            {
                return new OrderItemModel();
            }

            return new OrderItemModel
            {
                OrderId = addOrderItem.OrderId,
                ItemId = orderItem.ItemId,
                ProductId = addOrderItem.ProductId,
                ListPrice = addOrderItem.ListPrice,
                Discount = product.Discount,
                Quantity = addOrderItem.Quantity
            };
        }

        [HttpPost("CapNhatChiTietDonHang")]
        public bool CapNhatChiTietDonHang(OrderItemModel orderItem)
        {
            var updateOrderItem = new OrderItem
            {
                OrderId = orderItem.OrderId,
                ItemId = orderItem.ItemId,
                ProductId = orderItem.ProductId,
                ListPrice = orderItem.ListPrice,
                Discount = orderItem.Discount,
                Quantity = orderItem.Quantity
            };
            var update = _iXuLyDonDatHang.Sua(updateOrderItem);
            return update;
        }

        [HttpPost("XoaChiTietDonHang")]
        public bool XoaChiTietDonHang(OrderItemModel orderItem)
        {
            try
            {
                var chiTietDonHang = _iXuLyDonDatHang.ChiTietDonDatHang(orderItem.OrderId, orderItem.ItemId);
                if (chiTietDonHang == null) return false;
                var kq = _iXuLyDonDatHang.Xoa(chiTietDonHang);
                return kq;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost("TimKiem/{orderId}&{itemId}")]
        public OrderItemModel TimKiem(int orderId, int itemId)
        {
            var data = _iXuLyDonDatHang.Find(orderId, itemId);
            OrderItemModel orderItem = null;
            if (data != null)
            {
                orderItem = new OrderItemModel
                {
                    OrderId = data.OrderId,
                    ItemId = data.ItemId,
                    ProductId = data.ProductId,
                    ListPrice = data.ListPrice,
                    Discount = data.Discount,
                    Quantity = data.Quantity
                };
            }
            return orderItem;
        }

        [HttpPost("OrderItemExists/{orderId}&{itemId}")]
        public bool IsExists(int orderId, int itemId)
        {
            try
            {
                var data = _iXuLyDonDatHang.IsExists(orderId, itemId);
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
