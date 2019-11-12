using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WestWindSystem.DataModels.Class4;

namespace WestWindSystem.DataModels
{
    class Class2
    {
        public class OutstandingOrder
        {
            public int OrderId { get; set; }
            public string ShipToName { get; set; }
            public DateTime OrderDate { get; set; }
            public DateTime RequiredBy { get; set; }
            public int DaysRemaining { get; } //calculated
            public IEnumerable<OrderItem> OutstandingItems { get; set; }
            public string FullShippingAddress { get; set; }
            public string Comments { get; set; }
        }
    }
}
