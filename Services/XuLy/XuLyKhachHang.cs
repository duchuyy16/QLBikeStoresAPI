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
    public class XuLyKhachHang : BaseRepository<Customer>, IXuLyKhachHang
    {
        public XuLyKhachHang(demoContext context) : base(context) {}

        public List<Customer> DanhSachKhachHang()
        {
            var customers = _context.Customers.ToList();
            return customers;
        }
    }
}
