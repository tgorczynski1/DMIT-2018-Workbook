namespace WestWindSystem.DataModels
{
    partial class Class1
    {
        public class ShippingDirections
        {
            public int ShipperId { get; set; }
            public string TrackingCode { get; set; }
            public decimal? FreightCharge { get; set; } //Use decimal for all monetary values in c#


        }
        
     
    }
    
}
