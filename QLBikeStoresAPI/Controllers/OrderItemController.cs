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
        public OrderItemController(IXuLyDonDatHang iXuLyDonDatHang)
        {
            _iXuLyDonDatHang = iXuLyDonDatHang;
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
                    Quantity = item.Quantity
                };
                listOrders.Add(orderItem);
            }
            return listOrders;
        }

        [HttpPost("ChiTietDonDatHang/{orderId}&{itemId}")]
        public OrderItemModel ChiTietDonDatHang(int orderId, int itemId)
        {
            var orderDetails = _iXuLyDonDatHang.ChiTietDonDatHang(orderId,itemId);
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
            var newOrderItem = new OrderItem
            {
                OrderId= orderItem.OrderId,
                ItemId= orderItem.ItemId,
                ProductId = orderItem.ProductId,
                ListPrice = orderItem.ListPrice,
                Discount = orderItem.Discount,
                Quantity = orderItem.Quantity
            };
            var addOrderItem = _iXuLyDonDatHang.Them(newOrderItem);
            return new OrderItemModel
            {
                OrderId = addOrderItem.OrderId,
                ItemId = orderItem.ItemId,
                ProductId = addOrderItem.ProductId,
                ListPrice = addOrderItem.ListPrice,
                Discount = addOrderItem.Discount,
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
                var chiTietDonHang = _iXuLyDonDatHang.ChiTietDonDatHang(orderItem.OrderId,orderItem.ItemId);
                if (chiTietDonHang == null) return false;
                var kq = _iXuLyDonDatHang.Xoa(chiTietDonHang);
                return kq;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
