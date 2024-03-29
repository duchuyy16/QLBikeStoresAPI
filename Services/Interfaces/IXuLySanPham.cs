﻿using Services.Base;
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
        List<Product> DanhSachSanPhamBanChay();
        List<Product> DocDanhSachSanPhamTheoTheLoai(int categoryId);
        List<Product> DocDanhSachSanPhamTheoTheLoaiThuongHieu(int categoryId, int brandId);
        Product ChiTietSanPham(int id);
        List<Product> TimKiem(string name);
        Product Find(int id);
        bool IsExists(int id);
        
        List<Product> Search(string name,decimal? to,decimal? from);
    }

}
