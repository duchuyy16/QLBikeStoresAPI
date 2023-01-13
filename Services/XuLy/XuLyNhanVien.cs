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
            var staffs = _context.Staffs.Include(s => s.Manager).Include(s => s.Store).FirstOrDefault(s=>s.StaffId.Equals(id));
            return staffs;
        }

        public List<Staff> DanhSachNhanVien()
        {
            var staffs = _context.Staffs.Include(s => s.Manager).Include(s => s.Store).ToList();
            return staffs;
        }
    }
}
