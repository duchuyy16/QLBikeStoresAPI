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
    public class XuLyQuyen : BaseRepository<Role>, IXuLyQuyen
    {
        public XuLyQuyen(demoContext context) : base(context)
        {
        }

        public Role ChiTietQuyen(int id)
        {
            return _context.Roles.FirstOrDefault(m => m.RoleId == id);
        }

        public List<Role> DanhSachQuyen()
        {
            return _context.Roles.ToList();
        }
    }
}
