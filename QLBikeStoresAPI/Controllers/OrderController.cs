using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBikeStoresAPI.Models;
using Services.Interfaces;
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
    }
}
