using Services.Base;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IXuLyKhachHang : IBaseRepository<Customer>
    {
        List<Customer> DanhSachKhachHang();
        Customer ChiTietKhachHang(int id);
    }
}
