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
    public class OrderController : ControllerBase
    {
        public readonly IXuLyMuaHang _iXuLyMuaHang;
        public OrderController(IXuLyMuaHang iXuLyMuaHang)
        {
            _iXuLyMuaHang = iXuLyMuaHang;
        }

        [HttpPost("DocDanhSachMuaHang")]
        public List<OrderModel> DocDanhSachMuaHang()
        {
            var orders = _iXuLyMuaHang.DanhSachMuaHang();
            List<OrderModel> listorder = new List<OrderModel>();
            foreach (var item in orders)
            {
                OrderModel order = new OrderModel
                {
                    OrderId = item.OrderId,
                    CustomerId = item.CustomerId,
                    OrderDate = item.OrderDate,
                    OrderStatus = item.OrderStatus,
                    RequiredDate = item.RequiredDate,
                    ShippedDate = item.ShippedDate,
                    StaffId = item.StaffId,
                    StoreId = item.StoreId
                };
                listorder.Add(order);
            }
            return listorder;
        }

        [HttpPost("ChiTietMuaHang/{id}")]
        public OrderModel ChiTietMuaHang(int id)
        {
            var orderdetails = _iXuLyMuaHang.ChiTietMuaHang(id);
            OrderModel orderitem = null;
            if (orderdetails != null)
            {
                orderitem = new OrderModel
                {
                    OrderId = orderdetails.OrderId,
                    CustomerId=orderdetails.CustomerId,
                    OrderDate = orderdetails.OrderDate,
                    OrderStatus = orderdetails.OrderStatus,
                    RequiredDate = orderdetails.RequiredDate,
                    ShippedDate = orderdetails.ShippedDate,
                    StaffId = orderdetails.StaffId,
                    StoreId = orderdetails.StoreId
                };
            }
            return orderitem;
        }

        [HttpPost("ThemDonHang")]
        public OrderModel ThemDonHang(OrderModel order)
        {
            var newOrder = new Order
            {
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                OrderStatus = order.OrderStatus,
                RequiredDate = order.RequiredDate,
                ShippedDate = order.ShippedDate,
                StaffId = order.StaffId,
                StoreId = order.StoreId
            };
            var addOrder = _iXuLyMuaHang.Them(newOrder);
            return new OrderModel
            {
                CustomerId = addOrder.CustomerId,
                OrderDate = addOrder.OrderDate,
                OrderStatus = addOrder.OrderStatus,
                RequiredDate = addOrder.RequiredDate,
                ShippedDate = addOrder.ShippedDate,
                StaffId = addOrder.StaffId,
                StoreId = addOrder.StoreId
            };
        }

        [HttpPost("CapNhatDonHang")]
        public bool CapNhatDonHang(OrderModel order)
        {
            var updateOrder = new Order
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                OrderStatus = order.OrderStatus,
                RequiredDate = order.RequiredDate,
                ShippedDate = order.ShippedDate,
                StaffId = order.StaffId,
                StoreId = order.StoreId
            };
            var update = _iXuLyMuaHang.Sua(updateOrder);
            return update;
        }

        [HttpPost("XoaDonHang")]
        public bool XoaDonHang(OrderModel order)
        {
            try
            {
                var donHang = _iXuLyMuaHang.ChiTietMuaHang(order.OrderId);
                if (donHang  == null) return false;
                var kq = _iXuLyMuaHang.Xoa(donHang);
                return kq;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
