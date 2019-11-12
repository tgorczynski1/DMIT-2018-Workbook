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
	var output = ListShippers();
	output.Dump();
}

// Define other methods and classes here


public List<ShipperSelection> ListShippers()
        {
            //throw new NotImplementedException();
            // TODO: Get all the shippers from Db
			var result = from shipper in Shippers
						  orderby shipper.CompanyName
							select new ShipperSelection
							{
								ShipperId = shipper.ShipperID,
								Shipper = shipper.CompanyName
							};
			return result.ToList();
        }
		
public class ShipperSelection
        {
            public int ShipperId { get; set; }
            public string Shipper { get; set; }
        }