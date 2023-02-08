using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBikeStoresAPI.Models;
using Services.Interfaces;
using Services.Models;
using System;
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

        [HttpPost("ThemNhanHieu")]
        public BrandModel ThemNhanHieu(BrandModel brand)
        {
            var newBrand = new Brand
            {
                BrandName = brand.BrandName
            };
            var addStore = _iXuLyNhanHieu.Them(newBrand);
            return new BrandModel
            {
                BrandName = addStore.BrandName
            };
        }

        [HttpPost("CapNhatNhanHieu")]
        public bool CapNhatNhanHieu(BrandModel brand)
        {
            var updateBrand = new Brand
            {
                BrandId = brand.BrandId,
                BrandName = brand.BrandName
            };
            var update = _iXuLyNhanHieu.Sua(updateBrand);
            return update;
        }

        [HttpPost("XoaNhanHieu")]
        public bool XoaNhanHieu(BrandModel brand)
        {
            try
            {
                var nhanHieu = _iXuLyNhanHieu.ChiTietNhanHieu(brand.BrandId);
                if (nhanHieu == null) return false;
                var kq = _iXuLyNhanHieu.Xoa(nhanHieu);
                return kq;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost("TimKiem/{id}")]
        public BrandModel TimKiem(int id)
        {
            var data = _iXuLyNhanHieu.Find(id);
            BrandModel brandmodel=null;
            if(data!=null)
            {
                brandmodel = new BrandModel
                {
                    BrandId = data.BrandId,
                    BrandName = data.BrandName
                };    
            }
            return brandmodel;
        }

        [HttpPost("BrandExists/{id}")]
        public bool BrandExists(int id)
        {
            try
            {
                var data = _iXuLyNhanHieu.BrandExists(id);
                if (data != true) return false;
                else return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
