using Services.Base;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IXuLyNhanVien : IBaseRepository<Staff>
    {
        List<Staff> DanhSachNhanVien();
        Staff ChiTietNhanVien(int id);
    }
}
