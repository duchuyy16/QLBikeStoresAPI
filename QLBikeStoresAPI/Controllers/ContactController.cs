using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBikeStoresAPI.Helpers;
using QLBikeStoresAPI.Models;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLBikeStoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IXuLyLienLac _iXuLyLienLac;
        public ContactController(IXuLyLienLac iXuLyLienLac)
        {
            _iXuLyLienLac = iXuLyLienLac;
        }
        [HttpPost("ChiTiet/{id}")]
        public ContactModel ChiTiet(int id)
        {
            var contact = _iXuLyLienLac.ChiTietLienLac(id);
            ContactModel contactModel = null;
            if (contact != null)
                contactModel = new ContactModel
                {
                    Id = contact.Id,
                    Name = contact.Name,
                    Email = contact.Email,
                    Message = contact.Message,
                    CreateAt = contact.CreateAt,
                };
            return contactModel;
        }

        [HttpPost("DanhSachLienLac")]
        public List<ContactModel> DanhSachLienLac()
        {
            var contacts = _iXuLyLienLac.DanhSachLienLac();
            List<ContactModel> lstContactModels = new List<ContactModel>();
            foreach (var item in contacts)
            {
                ContactModel contactModel = new ContactModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    Message = item.Message,
                    CreateAt = item.CreateAt,
                };
                lstContactModels.Add(contactModel);
            }
            return lstContactModels;
        }
        [HttpPost("ThemLienLac")]
        public async Task<Contact> ThemLienLac(ContactModel contact)
        {
            var newContact = new Contact
            {
                Name = contact.Name,
                Email = contact.Email,
                Message = contact.Message,
                CreateAt = DateTime.Now,
            };
            var addCategory = _iXuLyLienLac.Them(newContact);
            if (addCategory!=null)
            {
                await EmailHelper.SendAsync(newContact.Email, newContact.Message);
            }
            return newContact;
        }

        [HttpPost("CapNhatLienLac")]
        public bool CapNhatLienLac(ContactModel contact)
        {
            var updateContact = new Contact
            {
                Id = contact.Id,
                Name = contact.Name,
                Email = contact.Email,
                Message = contact.Message,
                CreateAt = contact.CreateAt,
            };
            var update = _iXuLyLienLac.Sua(updateContact);
            return update;
        }

        [HttpPost("XoaLienLac")]
        public bool XoaLienLac(ContactModel contact)
        {
            try
            {
                var contact1 = _iXuLyLienLac.ChiTietLienLac(contact.Id);
                if (contact1 == null) return false;
                var kq = _iXuLyLienLac.Xoa(contact1);
                return kq;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost("TimKiem/{id}")]
        public ContactModel TimKiem(int id)
        {
            var data = _iXuLyLienLac.Find(id);
            ContactModel contact = null;
            if (data != null)
            {
                contact = new ContactModel
                {
                    Id = data.Id,
                    Name = data.Name,
                    Email = data.Email,
                    Message = data.Message,
                    CreateAt = data.CreateAt,
                };
            }
            return contact;
        }

        [HttpPost("ContactExists/{id}")]
        public bool IsExists(int id)
        {
            try
            {
                var data = _iXuLyLienLac.IsExists(id);
                if (data != true) return false;
                else return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
