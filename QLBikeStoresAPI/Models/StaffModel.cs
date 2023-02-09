using System.Collections.Generic;

namespace QLBikeStoresAPI.Models
{
    public class StaffModel
    {
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte Active { get; set; }
        public int? StoreId { get; set; }
        public int? ManagerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public StaffModel Manager { get; set; }
        public  RoleModel Role { get; set; }
        public  StoreModel Store { get; set; }
        public  List<StaffModel> InverseManager { get; set; }
        public List<OrderModel> Orders { get; set; }
    }

    public class StaffOrderModel
    {
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
