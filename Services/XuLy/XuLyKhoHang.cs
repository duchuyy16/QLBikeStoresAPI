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
    public class XuLyKhoHang : BaseRepository<Stock>, IXuLyKhoHang
    {
        public XuLyKhoHang(demoContext context) : base(context)
        {
        }

        public List<Stock> DocDanhSach()
        {
            var stocks = _context.Stocks.Include(s => s.Product).Include(s => s.Store).ToList();
            return stocks;
        }
    }
}
