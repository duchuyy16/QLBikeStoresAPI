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
        List<Product> DocDanhSachSanPhamTheoTheLoaiThuongHieu(int categoryId, int brandId);
        Product ChiTietSanPham(int id);
        List<Product> TimKiem(string name);

        public Task<int> ThemSanPham(Product product);
        public Task<Product> GetProduct(int id);
    }

}
