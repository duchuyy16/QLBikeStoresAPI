using Services.Base;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IXuLySanPham: IBaseRepository<Product>
    {
        List<Product> DocDanhSachSanPham();
        List<Product> DocDanhSachSanPhamTheoTheLoai(int categoryId);
        List<Product> DocDanhSachSanPhamTheoTheLoaiThuongHieu(int categoryId);
    }
}
