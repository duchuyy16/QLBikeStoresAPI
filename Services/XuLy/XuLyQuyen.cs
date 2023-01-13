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
            throw new NotImplementedException();
        }

        public List<Role> DanhSachQuyen()
        {
            throw new NotImplementedException();
        }
    }
}
