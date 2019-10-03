using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWindSystem.ReadModels
{
    public class SupplierProduct
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string PerUnitQuantity { get; set; }
    }
}
