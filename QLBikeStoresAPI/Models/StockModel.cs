namespace QLBikeStoresAPI.Models
{
    public class StockModel
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }

        public ProductStockModel Product { get; set; }
        public StoreModel Store { get; set; }
    }
    public class StockViewModel
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }

    }
}
