using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class MenuModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Brand> Brands { get; set; }
    }
}
