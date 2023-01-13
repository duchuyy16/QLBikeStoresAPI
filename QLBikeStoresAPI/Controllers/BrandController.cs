using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBikeStoresAPI.Models;
using Services.Interfaces;
using System.Collections.Generic;

namespace QLBikeStoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IXuLyNhanHieu _iXuLyNhanHieu;
        public BrandController(IXuLyNhanHieu iXuLyNhanHieu)
        {
            _iXuLyNhanHieu = iXuLyNhanHieu;
        }

        [HttpPost("DanhSachNhanHieu")]
        public List<BrandModel> DanhSachNhanHieu()
        {

            var brands = _iXuLyNhanHieu.DanhSachNhanHieu();
            List<BrandModel> listbrand = new List<BrandModel>();
            foreach (var item in brands)
            {
                BrandModel brand = new BrandModel
                {
                    BrandId = item.BrandId,
                    BrandName = item.BrandName
                };
                listbrand.Add(brand);
            }
            return listbrand;
        }

        [HttpPost("ChiTietNhanHieu/{id}")]
        public BrandModel ChiTietNhanHieu(int id)
        {

            var brands = _iXuLyNhanHieu.ChiTietNhanHieu(id);
            BrandModel brand = null;
            if (brands !=null)
            {
                brand = new BrandModel
                {
                    BrandId = brands.BrandId,
                    BrandName = brands.BrandName
                };
            }
            return brand;
        }
    }
}
