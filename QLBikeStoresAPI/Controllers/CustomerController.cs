using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBikeStoresAPI.Models;
using Services.Interfaces;
using Services.Models;
using System;
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
                    ZipCode=item.ZipCode,
                    Username=item.Username,
                    Password=item.Password,
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
                    ZipCode = customerdetails.ZipCode,
                    Username=customerdetails.Username,
                    Password=customerdetails.Password
                };
            }
            return customer;
        }

        [HttpPost("KiemTraUsername/{username}")]
        public CustomerModel KiemTraUsername(string username)
        {
            var data = _iXuLyKhachHang.KiemTraUsername(username);
            CustomerModel customer = null;
            if (data != null)
            {
                customer = new CustomerModel
                {
                    CustomerId = data.CustomerId,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Phone = data.Phone,
                    Email = data.Email,
                    Street = data.Street,
                    City = data.City,
                    State = data.State,
                    ZipCode = data.ZipCode,
                    Username = data.Username,
                    Password = data.Password
                };
            }
            return customer;
        }

        [HttpPost("DangNhap/{model}")]
        public CustomerModel DangNhap(LoginModel model)
        {
            var data = _iXuLyKhachHang.DangNhap(model); 
            CustomerModel customer = null;
            if (data != null)
            {
                customer = new CustomerModel
                {
                    CustomerId = data.CustomerId,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Phone = data.Phone,
                    Email = data.Email,
                    Street = data.Street,
                    City = data.City,
                    State = data.State,
                    ZipCode = data.ZipCode,
                    Username = data.Username,
                    Password = data.Password
                };
            }
            return customer;
        }

        [HttpPost("ThemKhachHang")]
        public CustomerModel ThemKhachHang(CustomerModel customer)
        {
            var newCustomer = new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Phone = customer.Phone,
                Email = customer.Email,
                Street = customer.Street,
                City = customer.City,
                State = customer.State,
                ZipCode = customer.ZipCode,
                Username = customer.Username,
                Password = customer.Password
            };
            var addCustomer = _iXuLyKhachHang.Them(newCustomer);
            return new CustomerModel
            {
                FirstName = addCustomer.FirstName,
                LastName = addCustomer.LastName,
                Phone = addCustomer.Phone,
                Email = addCustomer.Email,
                Street = addCustomer.Street,
                City = addCustomer.City,
                State = addCustomer.State,
                ZipCode = addCustomer.ZipCode,
                Username = addCustomer.Username,
                Password = addCustomer.Password
            };
        }

        [HttpPost("CapNhatKhachHang")]
        public bool CapNhatKhachHang(CustomerModel customer)
        {
            var updateCustomer = new Customer
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Phone = customer.Phone,
                Email = customer.Email,
                Street = customer.Street,
                City = customer.City,
                State = customer.State,
                ZipCode = customer.ZipCode,
                Username = customer.Username,
                Password = customer.Password
            };
            var update = _iXuLyKhachHang.Sua(updateCustomer);
            return update;
        }

        [HttpPost("XoaKhachHang")]
        public bool XoaKhachHang(CustomerModel customer)
        {
            try
            {
                var khachHang = _iXuLyKhachHang.ChiTietKhachHang(customer.CustomerId);
                if (khachHang == null) return false;
                var kq = _iXuLyKhachHang.Xoa(khachHang);
                return kq;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
