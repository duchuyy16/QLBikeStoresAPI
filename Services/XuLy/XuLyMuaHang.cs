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
    public class XuLyMuaHang : BaseRepository<Order>, IXuLyMuaHang
    {
        public XuLyMuaHang(demoContext context) : base(context)
        {
        }

        public Order ChiTietMuaHang(int id)
        {
            var orders = _context.Orders.Include(o => o.Customer).Include(o => o.Staff).Include(o => o.Store).FirstOrDefault(s=>s.OrderId.Equals(id));
            return orders;
        }

        public List<Order> DanhSachMuaHang()
        {
            var orders = _context.Orders.Include(o => o.Customer).Include(o => o.Staff).Include(o => o.Store).ToList();
            return orders;
        }

        public Order Find(int id)
        {
            return _context.Orders.Find(id);
        }

        public bool IsExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
