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

        public Stock ChiTiet(int productId, int storeId)
        {
            var stocks = _context.Stocks.Include(s => s.Product).Include(s => s.Store).FirstOrDefault(s=>s.ProductId==productId && s.StoreId==storeId);
            return stocks;
        }

        public List<Stock> DocDanhSach()
        {
            var stocks = _context.Stocks.Include(s => s.Product).Include(s => s.Store).ToList();
            return stocks;
        }

        public Stock Find(int productId, int storeId)
        {
            return _context.Stocks.Find(storeId, productId);
        }

        public bool IsExists(int productId, int storeId)
        {
            return _context.Stocks.Any(e => e.StoreId == storeId && e.ProductId == productId);
        }
    }
}
