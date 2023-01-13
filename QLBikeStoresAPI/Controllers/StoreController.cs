using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBikeStoresAPI.Models;
using Services.Interfaces;
using Services.Models;
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
            var storedetails = _iXuLyCuaHang.ChiTietCuaHang(id);
            StoreModel store = null;
            if(storedetails !=null)
            {
                store = new StoreModel
                {
                    StoreId = storedetails.StoreId,
                    StoreName = storedetails.StoreName,
                    Phone = storedetails.Phone,
                    City = storedetails.City,
                    Email = storedetails.Email,
                    State = storedetails.State,
                    Street = storedetails.Street,
                    ZipCode = storedetails.ZipCode,
                };
            } 
            return store;
        }
    }
}
