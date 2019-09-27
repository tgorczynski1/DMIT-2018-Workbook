<Query Kind="Expression">
  <Connection>
    <ID>05a2444e-14ea-4451-ad3d-3398e9ff7898</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// Display all the company names and contact names for our customers, grouped by country
from row in Customers
	//Customer	table<customer>
group  row   by   row.Address.Country into CustomersByCountry
	//Customer           string				Igrouping <string, customer>
//    \what/      \       how       /
select new		 //\      key      / 
{
   Country = CustomersByCountry.Key, // the key is "how" we have sorted the data
   Customers = from data in CustomersByCountry
               select new
               {
			       Company = data.CompanyName,
				   Contact = data.ContactName
               }
}