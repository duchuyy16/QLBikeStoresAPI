namespace QLBikeStoresAPI.Models
{
    public class StockModel
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        public ProductModel Product { get; set; }
        public StoreModel Store { get; set; }
    }
}
