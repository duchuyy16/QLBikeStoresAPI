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
                    StoreId = (int)item.StoreId,
                    ManagerId = item.ManagerId,
                    Username = item.Username,
                    Password = item.Password,
                    RoleId = item.RoleId
                };
                liststaff.Add(staff);
            }
            return liststaff;
        }

        [HttpPost("ChiTietNhanVien/{id}")]
        public StaffModel ChiTietNhanVien(int id)
        {
            var staffs = _iXuLyNhanVien.ChiTietNhanVien(id);
            StaffModel staff = null;
            if (staffs!=null)
            {
                staff = new StaffModel
                {
                    StaffId = staffs.StaffId,
                    FirstName = staffs.FirstName,
                    LastName = staffs.LastName,
                    Phone = staffs.Phone,
                    Email = staffs.Email,
                    Active = staffs.Active,
                    StoreId = (int)staffs.StoreId,
                    ManagerId = staffs.ManagerId,
                    Username=staffs.Username,
                    Password=staffs.Password,
                    RoleId=staffs.RoleId
                };
            }
            return staff;
        }
    }
}
