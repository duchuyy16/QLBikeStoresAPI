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
    public class StoreController : ControllerBase
    {
        public readonly IXuLyCuaHang _iXuLyCuaHang;
        public StoreController(IXuLyCuaHang iXuLyCuaHang)
        {
            _iXuLyCuaHang = iXuLyCuaHang;
        }

        [HttpPost("DocDanhSachCuaHang")]
        public List<StoreModel> DocDanhSachCuaHang()
        {
            var stores=_iXuLyCuaHang.DocDanhSachCuaHang();
            List<StoreModel> liststore = new List<StoreModel>();
            foreach(var item in stores)
            {
                StoreModel storemodel = new StoreModel
                {
                    StoreId = item.StoreId,
                    StoreName = item.StoreName,
                    Phone = item.Phone,
                    City = item.City,
                    Email = item.Email,
                    State = item.State,
                    Street = item.Street,
                    ZipCode = item.ZipCode,
                };
                liststore.Add(storemodel);
            }
            return liststore;
        }

        [HttpPost("ChiTietCuaHang/{id}")]
        public StoreModel ChiTietCuaHang(int id)
        {
            var storeDetails = _iXuLyCuaHang.ChiTietCuaHang(id);
            StoreModel store = null;
            if (storeDetails != null)
            {
                store = new StoreModel
                {
                    StoreId = storeDetails.StoreId,
                    StoreName = storeDetails.StoreName,
                    Phone = storeDetails.Phone,
                    City = storeDetails.City,
                    Email = storeDetails.Email,
                    State = storeDetails.State,
                    Street = storeDetails.Street,
                    ZipCode = storeDetails.ZipCode,
                };
            }
            return store;
        }

        [HttpPost("ThemCuaHang")]
        public StoreModel ThemCuaHang(StoreModel store)
        {
            var newStore = new Store
            {
                StoreName = store.StoreName,
                Phone = store.Phone,
                City = store.City,
                Email = store.Email,
                State = store.State,
                Street = store.Street,
                ZipCode = store.ZipCode
            };
            var addStore = _iXuLyCuaHang.Them(newStore);
            return new StoreModel
            {
                StoreName = addStore.StoreName,
                Phone = addStore.Phone,
                City = addStore.City,
                Email = addStore.Email,
                State = addStore.State,
                Street = addStore.Street,
                ZipCode = addStore.ZipCode
            };
        }

        [HttpPost("CapNhatCuaHang")]
        public bool CapNhatCuaHang(StoreModel store)
        {
            var updateStore = new Store
            {
                StoreId = store.StoreId,
                StoreName = store.StoreName,
                Phone = store.Phone,
                City = store.City,
                Email = store.Email,
                State = store.State,
                Street = store.Street,
                ZipCode = store.ZipCode
            };
            var update = _iXuLyCuaHang.Sua(updateStore);
            return update;
        }

        [HttpPost("XoaCuaHang")]
        public bool XoaCuaHang(StoreModel store)
        {
            try
            {
                var cuaHang = _iXuLyCuaHang.ChiTietCuaHang(store.StoreId);
                if (cuaHang == null) return false;
                var kq = _iXuLyCuaHang.Xoa(cuaHang);
                return kq;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
