using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBikeStoresAPI.Models;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace QLBikeStoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongKeController : ControllerBase
    {
        private readonly IXuLySanPham _iXuLySanPham;
        private readonly IXuLyTheLoaiSanPham _iXuLyTheLoai;
        public ThongKeController(IXuLySanPham _XuLySanPham, IXuLyTheLoaiSanPham _XuLyTheLoai)
        {
            _iXuLySanPham = _XuLySanPham;
            _iXuLyTheLoai = _XuLyTheLoai;
        }
        [HttpPost("ThongKeSanPhamTheoTheLoai")]
        public List<ThongKeModel.Output.ThongKeSanPhamTheoTheLoai> ThongKeSanPhamTheoTheLoai()
        {
            var dsTheLoai = _iXuLyTheLoai.DanhSachTheLoai();
            var dsSanPham = _iXuLySanPham.DocDanhSachSanPham();
            var Thongke = new List<ThongKeModel.Output.ThongKeSanPhamTheoTheLoai>();
            foreach (var tl in dsTheLoai)
            {
                var idtl = tl.CategoryId;
                var soluong = dsSanPham.Where(x => new List<int> { x.CategoryId }.Contains(idtl)).Count();
                Thongke.Add(new ThongKeModel.Output.ThongKeSanPhamTheoTheLoai
                {
                    IdTheLoai = tl.CategoryId,
                    TenTheLoai = tl.CategoryName,
                    SoLuongSanPham = soluong,
                });
            }
            return Thongke;
        }
    }

}
