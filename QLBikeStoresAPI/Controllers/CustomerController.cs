using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBikeStoresAPI.Models;
using Services.Interfaces;
using System.Collections.Generic;

namespace QLBikeStoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IXuLyKhachHang _iXuLyKhachHang;
        public CustomerController(IXuLyKhachHang iXuLyKhachHang)
        {
            _iXuLyKhachHang = iXuLyKhachHang;
        }


        [HttpPost("DanhSachKhachHang")]
        public List<CustomerModel> DanhSachKhachHang()
        {
            var customers = _iXuLyKhachHang.DanhSachKhachHang();
            List<CustomerModel> listcustomer = new List<CustomerModel>();
            foreach (var item in customers)
            {
                CustomerModel customer = new CustomerModel
                {
                    CustomerId = item.CustomerId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Phone=item.Phone,
                    Email=item.Email,
                    Street=item.Street,
                    City=item.City,
                    State=item.State,
                    ZipCode=item.ZipCode
                };
                listcustomer.Add(customer);
            }
            return listcustomer;
        }

        [HttpPost("ChiTietKhachHang/{id}")]
        public CustomerModel ChiTietKhachHang(int id)
        {
            var customerdetails = _iXuLyKhachHang.ChiTietKhachHang(id);
            CustomerModel customer = null;
            if(customerdetails != null)
            {
                customer = new CustomerModel
                {
                    CustomerId = customerdetails.CustomerId,
                    FirstName = customerdetails.FirstName,
                    LastName = customerdetails.LastName,
                    Phone = customerdetails.Phone,
                    Email = customerdetails.Email,
                    Street = customerdetails.Street,
                    City = customerdetails.City,
                    State = customerdetails.State,
                    ZipCode = customerdetails.ZipCode
                };
            }
            return customer;
        }
    }
}
