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
    public class RoleController : ControllerBase
    {
        private readonly IXuLyQuyen _iXuLyQuyen;
        public RoleController(IXuLyQuyen iXuLyQuyen)
        {
            _iXuLyQuyen = iXuLyQuyen;
        }

        [HttpPost("DanhSachQuyen")]
        public List<RoleModel> DanhSachNhanVien()
        {
            var roles = _iXuLyQuyen.DanhSachQuyen();
            List<RoleModel> listRole = new List<RoleModel>();
            foreach (var item in roles)
            {
                RoleModel role = new RoleModel
                {
                    RoleId = item.RoleId,
                    RoleName=item.RoleName,
                };
                listRole.Add(role);
            }
            return listRole;
        }


        [HttpPost("ChiTietQuyen")]
        public RoleModel ChiTiet(int id)
        {
            var roleDetails = _iXuLyQuyen.ChiTietQuyen(id);
            RoleModel role = null;
            if (roleDetails != null)
                role = new RoleModel
                {
                    RoleId = roleDetails.RoleId,
                    RoleName = roleDetails.RoleName,
                };
            return role;
            
        }

        [HttpPost("ThemQuyen")]
        public RoleModel ThemQuyen(RoleModel role)
        {
            var newRole = new Role
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
            };
            var addRole = _iXuLyQuyen.Them(newRole);
            return new RoleModel 
            { RoleId = newRole.RoleId, RoleName = newRole.RoleName };

        }

        [HttpPost("CapNhatQuyen")]
        public bool CapNhatQuyen(RoleModel role)
        {
            var updateRole = new Role
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
            };
            var update = _iXuLyQuyen.Sua(updateRole);
            return update;
        }

        [HttpPost("XoaQuyen")]
        public bool XoaQuyen(RoleModel role)
        {
            try
            {
                var roles = _iXuLyQuyen.ChiTietQuyen(role.RoleId);
                if (roles == null) return false;
                var kq = _iXuLyQuyen.Xoa(roles);
                return kq;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
