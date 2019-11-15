using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.DataModels;
using static WestWindSystem.DataModels.Class1;
using static WestWindSystem.DataModels.Class2;
using static WestWindSystem.DataModels.Class3;
using static WestWindSystem.DataModels.Class4;

namespace WestWindSystem.BLL
{
    [DataObject]
    public class OrderProcessingController
    {
        #region Queries

        //[DataObjectMethod(DataObjectMethodType.Select)]
        public List<OutstandingOrder> LoadOrders(int supplierId)
        {
            // TODO: implement this method with the following
            /*- Make sure the supplier ID exists, otherwise throw an exception
             *    Validation:
                 - [Advanced:] *Make sure the logged-in user works for the identified supplier. * 
                 - Query for outstanding orders, getting data from the following tables: 
                 - TODO: List table names
             * 
             */
            using (var context = new WestWindContext()) //using my DAL object 
            {
                //validation
                var supplier = context.Suppliers.Find(supplierId);
                if (supplier == null)
                    throw new Exception("Invalid supplier - unable to load orders");
                //processing
                var result =
                    from sale in context.Orders
                    where !sale.Shipped && sale.OrderDate.HasValue
                    select new OutstandingOrder
                        {
                            OrderId = sale.OrderID,
                            ShipToName = sale.ShipName,
                            OrderDate = sale.OrderDate.Value,
                            RequiredBy = sale.RequiredDate.Value,
                            //DaysRemaining = 
                            OutstandingItems = from item in sale.OrderDetails
                           select new OrderItem
                           {
                               ProductID = item.ProductID,
                               ProductName = item.Product.ProductName,
                               Qty = item.Quantity,
                               QtyPerUnit = item.Product.QuantityPerUnit
                               // TODO: Figure out the Outstanding quantity
                               //								Outstanding = (from ship in item.Order.Shipments
                               //												from shipItem in ship.ManifestItems
                               //												where shipItem.ProductID == item.ProductID
                               //												select shipItem.ShipQuantity).Sum()
                           },
                                FullShippingAddress = // TODO: how to use sale.ShipAddressID,
                                sale.Customer.Address.Street + Environment.NewLine +
                                sale.Customer.Address.City + ", " +
                                sale.Customer.Address.Region + Environment.NewLine +
                                sale.Customer.Address.Country + " " +
                                sale.Customer.Address.PostalCode,
                                Comments = sale.Comments
                     };
                return result.ToList();
            }
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
