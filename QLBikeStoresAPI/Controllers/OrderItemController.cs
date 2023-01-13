using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBikeStoresAPI.Models;
using Services.Interfaces;
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
            var oderitems = _iXuLyDonDatHang.DanhSachDonDatHang();
            List<OrderItemModel> listorders = new List<OrderItemModel>();
            foreach (var item in oderitems)
            {
                OrderItemModel orderitem = new OrderItemModel
                {
                    OrderId = item.OrderId,
                    ItemId = item.ItemId,
                    ProductId = item.ProductId,
                    ListPrice = item.ListPrice,
                    Discount = item.Discount,
                    Quantity = item.Quantity
                };
                listorders.Add(orderitem);
            }
            return listorders;
        }

        [HttpPost("ChiTietDonDatHang/{orderId}&{itemId}")]
        public OrderItemModel ChiTietDonDatHang(int orderId, int itemId)
        {
            var orderdetails = _iXuLyDonDatHang.ChiTietDonDatHang(orderId,itemId);
            OrderItemModel orderitem = null;
            if (orderdetails!=null)
            {
                orderitem = new OrderItemModel
                {
                    OrderId = orderdetails.OrderId,
                    ItemId = orderdetails.ItemId,
                    ProductId = orderdetails.ProductId,
                    ListPrice = orderdetails.ListPrice,
                    Discount = orderdetails.Discount,
                    Quantity = orderdetails.Quantity
                };
            }
            return orderitem;
        }
    }
}
