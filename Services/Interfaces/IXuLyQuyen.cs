using Services.Base;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IXuLyQuyen:IBaseRepository<Role>
    {
        List<Role> DanhSachQuyen();
        Role ChiTietQuyen(int id);
        Role Find(int id);
        bool IsExists(int id);
    }
}
