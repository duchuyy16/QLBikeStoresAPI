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
                    StoreId = item.StoreId,
                    Customer = item.Customer.Adapt<CustomerModel>(),
                    Staff = item.Staff.Adapt<StaffModel>(),
                    Store = item.Store.Adapt<StoreModel>(),
                    OrderItems = item.OrderItems.Adapt<List<OrderItemModel>>()
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
                    StoreId = orderdetails.StoreId,
                    Customer = orderdetails.Customer.Adapt<CustomerModel>(),
                    Staff = orderdetails.Staff.Adapt<StaffModel>(),
                    Store = orderdetails.Store.Adapt<StoreModel>(),
                    OrderItems = orderdetails.OrderItems.Adapt<List<OrderItemModel>>()
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

        [HttpPost("TimKiem/{id}")]
        public OrderModel TimKiem(int id)
        {
            var data = _iXuLyMuaHang.Find(id);
            OrderModel order = null;
            if (data != null)
            {
                order = new OrderModel
                {
                    OrderId = data.OrderId,
                    CustomerId = data.CustomerId,
                    OrderDate = data.OrderDate,
                    OrderStatus = data.OrderStatus,
                    RequiredDate = data.RequiredDate,
                    ShippedDate = data.ShippedDate,
                    StaffId = data.StaffId,
                    StoreId = data.StoreId,
                    Customer = data.Customer.Adapt<CustomerModel>(),
                    Staff = data.Staff.Adapt<StaffModel>(),
                    Store = data.Store.Adapt<StoreModel>(),
                    OrderItems = data.OrderItems.Adapt<List<OrderItemModel>>()
                };
            }
            return order;
        }

        [HttpPost("OrderExists/{id}")]
        public bool IsExists(int id)
        {
            try
            {
                var data = _iXuLyMuaHang.IsExists(id);
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
