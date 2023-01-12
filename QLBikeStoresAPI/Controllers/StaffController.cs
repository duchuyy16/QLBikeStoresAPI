using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBikeStoresAPI.Models;
using Services.Interfaces;
using System.Collections.Generic;

namespace QLBikeStoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IXuLyNhanVien _iXuLyNhanVien;
        public StaffController(IXuLyNhanVien iXuLyNhanVien)
        {
            _iXuLyNhanVien = iXuLyNhanVien;
        }


        [HttpPost("DanhSachNhanVien")]
        public List<StaffModel> DanhSachNhanVien()
        {
            var staffs = _iXuLyNhanVien.DanhSachNhanVien();
            List<StaffModel> liststaff = new List<StaffModel>();
            foreach (var item in staffs)
            {
                StaffModel staff = new StaffModel
                {
                    StaffId = item.StaffId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Phone = item.Phone,
                    Email = item.Email,
                    Active = item.Active,
                    StoreId = item.StoreId,
                    ManagerId = item.ManagerId
                };
                liststaff.Add(staff);
            }
            return liststaff;
        }
    }
}
