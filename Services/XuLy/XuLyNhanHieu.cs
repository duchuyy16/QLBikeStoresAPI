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
    internal class XuLyNhanHieu : BaseRepository<Brand>, IXuLyNhanHieu
    {
        public XuLyNhanHieu(demoContext context) : base(context){}

        public List<Brand> DanhSachNhanHieu()
        {
            var brands = _context.Brands.ToList();
            return brands;
        }
    }
}
