using Services.Base;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    internal interface IXuLySanPham: IBaseRepository<Product>
    {
        List<Product> DocDanhSachSanPham();
        Product DocDanhSachSanPhamTheoTheLoai(int categoryId);
        Product DocDanhSachSanPhamTheoTheLoaiThuongHieu(int categoryId);
    }
}
