<Query Kind="Expression">
  <Connection>
    <ID>af508a97-5670-42ec-b71b-8cc473cabf0e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>GroceryList</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//Select all orders a picker has done on a particular week (Sunday through Saturday). 
//Group and sorted by picker. Sort the orders by picked date. Hint: you will need to use the join operator.
//
//DateTime start = new DateTime(2017,12,30) // Last date of a picked order, is a Sunday
//                 .AddDays(-14);         // Go two weeks earlier
//DateTime end = start.AddDays(7);
//var diff = end - start;
//diff.Dump("Time between two dates");

//var picker = Pickers.Select(person => person.LastName + " " + person.FirstName);
//var alphabetical = picker.OrderBy(name => name);

//var result = from sale in Orders
//             where sale.OrderDate >= start
//			    && sale.OrderDate < end
//			 //join pk in Pickers on sale.PickerID equals pk.PickerID into tt
//			 orderby sale.PickedDate			 
//			 group sale by sale.PickerID into pickedOrders		
//			 select new
//			 {
//			     Picker = //pickedOrders.Key,	
//				 			(from picker in pickedOrders
//				 			join pk in Pickers on picker.PickerID equals pk.PickerID
//							orderby pk.LastName
//				 			select new
//							{
//								picker = pk.LastName + ", " + pk.FirstName
//							}).Distinct(),
//				 			//Pickers.Select(person => person.LastName + " " + person.FirstName),
//				          //Pickers.Single(x => x.PickerID == pickedOrders.Key),
//				 Orders = from picked in pickedOrders
//				          select new
//						  {
//						      ID 	= picked.OrderID,
//							  Date  = picked.PickedDate
//						  }
//			 };
//result.Dump();

//var HighestToLowest = result.OrderBy(sale => sale.Category);
//HighestToLowest.Dump();







