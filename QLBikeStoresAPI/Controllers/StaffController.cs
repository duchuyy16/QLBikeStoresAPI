using Mapster;
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
    public class StaffController : ControllerBase
    {
        private readonly IXuLyNhanVien _iXuLyNhanVien;
        public StaffController(IXuLyNhanVien iXuLyNhanVien)
        {
            _iXuLyNhanVien = iXuLyNhanVien;
        }


        [HttpPost("DocDanhSachNhanVien")]
        public List<StaffModel> DanhSachNhanVien()
        {
            var staffs = _iXuLyNhanVien.DanhSachNhanVien();
            List<StaffModel> listStaff = new List<StaffModel>();
            foreach (var item in staffs)
            {
                StaffModel staffmodel = new StaffModel
                {
                    StaffId = item.StaffId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Phone = item.Phone,
                    Email = item.Email,
                    Active = item.Active,
                    StoreId = item.StoreId,
                    ManagerId = item.ManagerId,
                    Username = item.Username,
                    Password = item.Password,
                    RoleId = item.RoleId,
                    Role = item.Role.Adapt<RoleModel>(),
                    Store = item.Store.Adapt<StoreModel>()
                };
                listStaff.Add(staffmodel);
            }
            return listStaff;
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
                    RoleId=staffs.RoleId,
                    Role = staffs.Role.Adapt<RoleModel>(),
                    Store = staffs.Store.Adapt<StoreModel>(),
                };
            }
            return staff;
        }

        [HttpPost("DangNhap")]
        public StaffModel DangNhap(LoginModel model)
        {
            var data = _iXuLyNhanVien.DangNhap(model);
            StaffModel staff = null;
            if (data != null)
            {
                staff = new StaffModel
                {
                    StaffId = data.StaffId,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Phone = data.Phone,
                    Email = data.Email,
                    Active = data.Active,
                    StoreId = data?.StoreId,
                    ManagerId = data?.ManagerId,
                    Username = data.Username,
                    Password = data.Password,
                    RoleId = data.RoleId,
                    Role = data.Role.Adapt<RoleModel>(),
                    Store = data.Store != null ? data.Store.Adapt<StoreModel>() : new StoreModel(),
                };
            }
            return staff;
        }

        [HttpPost("ThemNhanVienMoi")]
        public StaffModel ThemNhanVien(StaffModel staff)
        {
            var newStaff = new Staff
            {            
                FirstName = staff.FirstName,
                LastName = staff.LastName,
                Phone = staff.Phone,
                Email = staff.Email,
                Active = staff.Active,
                StoreId = staff.StoreId,
                ManagerId = staff.ManagerId,
                Username = staff.Username,
                Password = staff.Password,
                RoleId = staff.RoleId,
            };
            var addNV = _iXuLyNhanVien.Them(newStaff);
            return new StaffModel
            {
                FirstName = addNV.FirstName,
                LastName = addNV.LastName,
                Phone = addNV.Phone,
                Email = addNV.Email,
                Active = addNV.Active,
                StoreId = addNV.StoreId,
                ManagerId = addNV.ManagerId,
                Username = addNV.Username,
                Password = addNV.Password,
                RoleId = addNV.RoleId,
            };
        }

        [HttpPost("CapNhatNhanVien")]
        public bool CapNhatNhanVien(StaffModel staff)
        {
            var updateStaff = new Staff
            {
                StaffId = staff.StaffId,
                FirstName = staff.FirstName,
                LastName = staff.LastName,
                Phone = staff.Phone,
                Email = staff.Email,
                Active = staff.Active,
                StoreId = staff?.StoreId,
                ManagerId = staff.ManagerId,
                Username = staff.Username,
                Password = staff.Password,
                RoleId = staff.RoleId
            };
            var update = _iXuLyNhanVien.Sua(updateStaff);
            return update;
        }

        [HttpPost("XoaNhanVien")]
        public bool XoaNhanVien(StaffModel staff)
        {
            try
            {
                var nhanVien = _iXuLyNhanVien.ChiTietNhanVien(staff.StaffId);
                if (nhanVien == null) return false;
                var kq = _iXuLyNhanVien.Xoa(nhanVien);
                return kq;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost("TimKiem/{id}")]
        public StaffModel TimKiem(int id)
        {
            var data = _iXuLyNhanVien.Find(id);
            StaffModel staff = null;
            if (data != null)
            {
                staff = new StaffModel
                {
                    StaffId = data.StaffId,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Phone = data.Phone,
                    Email = data.Email,
                    Active = data.Active,
                    StoreId = data?.StoreId,
                    ManagerId = data.ManagerId,
                    Username = data.Username,
                    Password = data.Password,
                    RoleId = data.RoleId,
                    Role = data.Role.Adapt<RoleModel>(),
                    Store = data.Store != null ? data.Store.Adapt<StoreModel>() : new StoreModel(),
                };
            }
            return staff;
        }

        [HttpPost("StaffExists/{id}")]
        public bool IsExists(int id)
        {
            try
            {
                var data = _iXuLyNhanVien.IsExists(id);
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
