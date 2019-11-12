using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWindSystem.DataModels
{
    class Class5
    {
        public class ShippingDirections
        {
            public int ShipperId { get; set; }
            public string TrackingCode { get; set; }
            public decimal? FreightCharge { get; set; } //Use decimal for all monetary values in c#


        }
    }
}
