using System.Collections.Generic;

namespace QLBikeStoresAPI.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public short ModelYear { get; set; }
        public decimal ListPrice { get; set; }
        public string ImageBike { get; set; }
        public decimal Discount { get; set; }
        public string Describe { get; set; }
        public CategoryModel Category { get; set; }
        public List<StockModel> Stocks { get; set; }
        public BrandModel Brand { get; set; }
        
    }
}
