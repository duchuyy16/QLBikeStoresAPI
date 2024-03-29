﻿namespace QLBikeStoresAPI.Models
{
    public class OrderItemModel
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal ListPrice { get; set; }
        public decimal Discount { get; set; }
        public OrderViewModel Order { get; set; }
        public ProductStockModel Product { get; set; }
    }
}
