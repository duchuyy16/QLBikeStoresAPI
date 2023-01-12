using Microsoft.AspNetCore.Mvc;
using QLBikeStoresAPI.Models;
using Services.Interfaces;
using System.Collections.Generic;

namespace QLBikeStoresAPI.Controllers
{
    public class BrandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost("DanhSachNhanHieu")]
        //public List<BrandModel> DanhSachNhanHieu()
        //{
         
        //    //List<StoreModel> liststore = new List<StoreModel>();
        //    //foreach (var item in store)
        //    //{
        //    //    StoreModel storemodel = new StoreModel
        //    //    {
        //    //        StoreId = item.StoreId,
        //    //        StoreName = item.StoreName,
        //    //        Phone = item.Phone,
        //    //        City = item.City,
        //    //        Email = item.Email,
        //    //        State = item.State,
        //    //        Street = item.Street,
        //    //        ZipCode = item.ZipCode,
        //    //    };
        //    //    liststore.Add(storemodel);
        //    //}
        //    //return liststore;
        //}
    }
}
