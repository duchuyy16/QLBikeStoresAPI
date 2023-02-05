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

        public Customer ChiTietKhachHang(int id)
        {
            var customers = _context.Customers.FirstOrDefault(c=>c.CustomerId.Equals(id));
            return customers;
        }

        public List<Customer> DanhSachKhachHang()
        {
            var customers = _context.Customers.ToList();
            return customers;
        }

        public Customer DangKy(SignUp model)
        {
            var data = new Customer()
            {
                FirstName = model.Firstname,
                LastName = model.Lastname,
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,
                Phone = model.Phone,
            };
            _context.Customers.Add(data);
            _context.SaveChanges();
            return data;
        }

        public Customer DangNhap(LoginModel model)
        {
            var data = _context.Customers.Where(s => s.Username == model.Username).FirstOrDefault();
            return data;
        }

        public Customer KiemTraUsername(string username)
        {
            var data = _context.Customers.Where(e => e.Username == username).SingleOrDefault();
            return data;
        }
    }
}
