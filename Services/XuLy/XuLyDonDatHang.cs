using Microsoft.EntityFrameworkCore;
using Services.Base;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.XuLy
{
    public class XuLyDonDatHang : BaseRepository<OrderItem>, IXuLyDonDatHang
    {
        public XuLyDonDatHang(demoContext context) : base(context)
        {
        }

        public OrderItem ChiTietDonDatHang(int orderId,int itemId)
        {
            var orderitems = _context.OrderItems.Include(o => o.Order).Include(o => o.Product).FirstOrDefault(o=>o.OrderId==orderId && o.ItemId==itemId);
            return orderitems;
        }

        public List<OrderItem> DanhSachDonDatHang()
        {
            var orderitems=_context.OrderItems.Include(o => o.Order).Include(o => o.Product).ToList();
            return orderitems;
        }

        public OrderItem Find(int orderId, int itemId)
        {
            return _context.OrderItems.Find(orderId, itemId);
        }

        public int FindMaxId()
        {
            return _context.OrderItems.Max(o => o.OrderId);
        }

        public bool IsExists(int orderId, int itemId)
        {
            return _context.OrderItems.Any(e => e.OrderId == orderId && e.ItemId == itemId);
        }
    }
}
