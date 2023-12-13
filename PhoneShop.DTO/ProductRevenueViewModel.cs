using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneShop.DTO
{
   public class ProductRevenueViewModel
    {
        public int ProductType { get; set; }
        public string TypeName { get; set; }
        public double? TotalRevenue { get; set; }
    }
}
