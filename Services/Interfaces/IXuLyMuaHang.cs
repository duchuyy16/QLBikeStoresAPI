﻿using Services.Base;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IXuLyMuaHang:IBaseRepository<Order>
    {
        List<Order> DanhSachMuaHang();
        Order ChiTietMuaHang(int id);
        Order Find(int id);
        bool IsExists(int id);
    }
}
