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
    public class XuLyCuaHang : BaseRepository<Store>, IXuLyCuaHang
    {
        public XuLyCuaHang(demoContext context) : base(context) { }

        public List<Store> DocDanhSachCuaHang()
        {
            var stores = _context.Stores.ToList();
            return stores;
        }
    }

}
