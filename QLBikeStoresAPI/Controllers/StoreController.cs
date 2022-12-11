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

        [HttpGet("DocDanhSachCuaHang")]
        public List<StoreModel> DocDanhSachCuaHang()
        {
            var store=_iXuLyCuaHang.DocDanhSachCuaHang();
            List<StoreModel> liststore = new List<StoreModel>();
            foreach(var item in store)
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
    }
}
