using Microsoft.EntityFrameworkCore;
using Services.Base;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.XuLy
{
    public class XuLyNhanVien : BaseRepository<Staff>, IXuLyNhanVien
    {
        public XuLyNhanVien(demoContext context) : base(context)
        {
        }

        public Staff ChiTietNhanVien(int id)
        {
            var staffs = _context.Staffs.Include(s => s.Manager).Include(s => s.Store).FirstOrDefault(s => s.StaffId.Equals(id));
            return staffs;
        }

        public Staff DangNhap(LoginModel model)
        {
            var data = _context.Staffs.Where(s => s.Username == model.Username).Include(r=>r.Role).FirstOrDefault();
            return data;
        }

        public List<Staff> DanhSachNhanVien()
        {
            var staffs = _context.Staffs.Include(s => s.Manager).Include(s => s.Store).Include(r => r.Role).ToList();
            return staffs;
        }

        public Staff Find(int id)
        {
            return _context.Staffs.Find(id);
        }

        public bool IsExists(int id)
        {
            return _context.Staffs.Any(e => e.StaffId == id);
        }
    }
}
