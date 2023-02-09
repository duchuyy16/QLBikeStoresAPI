using System;
using System.Collections.Generic;

namespace QLBikeStoresAPI.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public byte OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int StoreId { get; set; }
        public int StaffId { get; set; }
        public  CustomerModel Customer { get; set; }
        public StaffOrderModel Staff { get; set; }
        public  StoreModel Store { get; set; }
        public  List<OrderItemModel> OrderItems { get; set; }
    }

    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public byte OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
    }
}
