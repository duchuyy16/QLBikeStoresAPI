using Services.Models;
using System.Collections.Generic;

namespace QLBikeStoresAPI.Models
{
    public class MenuViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Brand> Brands { get; set; }
    }
}
