using Services.Base;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IXuLyTheLoaiSanPham:IBaseRepository<Category>
    {
        Category DocThongTin(int id);
    }
}
