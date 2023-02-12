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
    public class XuLyLienLac : BaseRepository<Contact>, IXuLyLienLac
    {
        public XuLyLienLac(demoContext context) : base(context)
        {
        }

        public Contact ChiTietLienLac(int id)
        {
            return _context.Contacts.FirstOrDefault(m => m.Id == id);
        }

        public List<Contact> DanhSachLienLac()
        {
            return _context.Contacts.ToList();
        }

        public Contact Find(int id)
        {
            return _context.Contacts.Find(id);
        }

        public bool IsExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}
