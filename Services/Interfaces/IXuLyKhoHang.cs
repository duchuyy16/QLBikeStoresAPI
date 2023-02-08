using Services.Base;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IXuLyKhoHang:IBaseRepository<Stock>
    {
        List<Stock> DocDanhSach();
        Stock ChiTiet(int productId,int storeId);
        Stock Find(int productId, int storeId);
        bool IsExists(int productId, int storeId);
    }
}
