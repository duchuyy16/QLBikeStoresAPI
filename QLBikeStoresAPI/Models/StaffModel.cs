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
    }
}
