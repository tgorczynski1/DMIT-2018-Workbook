<Query Kind="Program">
  <Connection>
    <ID>8e8a6d6e-162a-4d00-b57b-6cff24dacb70</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

void Main()
{
	int supplier = 8; // 2,7, 8, 16, 19
	var output = LoadOrders(supplier);
	output.Dump();
}

public List<OutstandingOrder> LoadOrders(int supplierId)
{
	var result =
	from sale in Orders
	where !sale.Shipped && sale.OrderDate.HasValue
	select new OutstandingOrder
	{
	};
	return result.ToList();
}


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
		
public class OrderItem
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public short Qty { get; set; }
            public string QtyPerUnit { get; set; }
            public short Outstanding { get; set; } // calculated as OrderDetails.Quantity - Sum  (shipped quantity)
        }