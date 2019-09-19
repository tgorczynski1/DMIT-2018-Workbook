<Query Kind="Program">
  <Connection>
    <ID>e7166e65-f095-499c-8c33-52f4e03b6a19</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

void Main()
{
	// List the first and last name of all the employees who look after 7 or more territories
	// as well as the names of all the territories they are responsible for
	var result = 
	from person in Employees
	where person.EmployeeTerritories.Count >= 7
	select new TerritorialSalesRep
	{
	   Title = person.JobTitle,
	   First = person.FirstName,
	   Last = person.LastName,
	   Territories = from place in person.EmployeeTerritories
	                 select place.Territory.TerritoryDescription
	};
	result.Dump();
}

// Define other methods and classes here

public class TerritorialSalesRep
{
	public string Title {get; set;}
	public string First {get; set;}
	public string Last {get; set;}
	public IEnumerable<string> Territories {get; set;}

}


