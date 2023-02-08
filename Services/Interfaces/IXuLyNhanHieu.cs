using Services.Base;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IXuLyNhanHieu : IBaseRepository<Brand>
    {
        List<Brand> DanhSachNhanHieu();
        List<Brand> DanhSachNhanHieuTheoDieuKien(int category);
        Brand ChiTietNhanHieu(int id);
        Brand Find(int id);
        bool BrandExists(int id);
    }
}
