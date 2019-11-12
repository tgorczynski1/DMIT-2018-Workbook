using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWindSystem.DataModels
{
    class Class4
    {
        public class OrderItem
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public short Qty { get; set; }
            public string QtyPerUnit { get; set; }
            public short Outstanding { get; set; } // calculated as OrderDetails.Quantity - Sum  (shipped quantity)
        }
    }
}
