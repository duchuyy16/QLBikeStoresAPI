using Services.Base;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IXuLyLienLac : IBaseRepository<Contact>
    {
        List<Contact> DanhSachLienLac();
        Contact ChiTietLienLac(int id);
        Contact Find(int id);
        bool IsExists(int id);
    }
}
