using System.Collections.Generic;

namespace QLBikeStoresAPI.Models
{
    public class MenuModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<BrandModel> Brands { get; set; }
    }
}
