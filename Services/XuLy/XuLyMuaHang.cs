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

        public List<Order> DanhSachMuaHang()
        {
            var orders = _context.Orders.Include(o => o.Customer).Include(o => o.Staff).Include(o => o.Store).ToList();
            return orders;
        }
    }
}
