using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.DataModels;
using static WestWindSystem.DataModels.Class1;
using static WestWindSystem.DataModels.Class2;
using static WestWindSystem.DataModels.Class3;

namespace WestWindSystem.BLL
{
    class OrderProcessingController
    {
        #region Queries
        public List<OutstandingOrder> LoadOrders(int supplierId)
        {
            throw new NotImplementedException();
            // TODO: implement this method with the following
            /*- Make sure the supplier ID exists, otherwise throw an exception
             *    Validation:
                 - [Advanced:] *Make sure the logged-in user works for the identified supplier. * 
                 - Query for outstanding orders, getting data from the following tables: 
                 - TODO: List table names
             * 
             */
        }
        public List<ShipperSelection> ListShippers()
        {
            using (var context = new WestWindContext())
            {
                var result = from shipper in context.Shippers
                             orderby shipper.CompanyName
                             select new ShipperSelection
                             {
                                 ShipperId = shipper.ShipperID,
                                 Shipper = shipper.CompanyName
                             };
                return result.ToList();
            }
                
        }
        #endregion
        #region Commands
        public void ShipOrder(int orderId, ShippingDirections shipping, List<ShippedItem> items)
        {
            /* TODO: Validation Steps 
             * Validation**
                 - OrderId must be valid
                 - `ShippingDirections` is required (cannot be `null`)
                 - List<ShippedItem> cannot be empty/null
                 - The products must be on the order && items that this supplier provides 
                 - Quantites must be greater than zero and less than or equal to the quantity outstanding
                 - Shipper must exist 
                 - Freight charge must be either null (no charge) or > $0.00
             * TODO: Prcoess the order shipment 
             * Processing** (tables/data that must be updated/inserted/deleted/whatever)
                - Create new shipment
                - Add all manifest items
                - check if order is complete; if so, update Order.Shipped
             */
        }
        #endregion
    }
}
