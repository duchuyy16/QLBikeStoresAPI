using Services.Base;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IXuLyDonDatHang : IBaseRepository<OrderItem>
    {
        List<OrderItem> DanhSachDonDatHang();
        OrderItem ChiTietDonDatHang(int orderId,int itemId);
        OrderItem Find(int orderId, int itemId);
        bool IsExists(int orderId, int itemId);
    }
}
