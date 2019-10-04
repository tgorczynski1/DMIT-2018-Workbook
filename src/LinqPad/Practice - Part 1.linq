<Query Kind="Expression">
  <Connection>
    <ID>6ae06d34-9504-48a1-82b9-85bb2c60c64c</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <AlphabetizeColumns>true</AlphabetizeColumns>
  </Connection>
</Query>

// Practice questions - do each one in a separate LinqPad query.
/*

A) List all the customer company names for those with more than 5 orders.
B) Get a list of all the region names
C) Get a list of all the territory names
D) List all the regions and the number of territories in each region
E) List all the region and territory names in a "flat" list
F) List all the region and territory names as an "object graph"
   - use a nested query
G) List all the product names that contain the word "chef" in the name.
H) List all the discontinued products, specifying the product name and unit price.
I) List the company names of all Suppliers in North America (Canada, USA, Mexico)

*/
//A.
from person in Customers
where person.Orders.Count > 5
select new 
{
		person.CompanyName,
		person.Orders.Count
}

//B. 

from row in Regions
select row.RegionDescription

//C. 

from row in Territories
select row.TerritoryDescription

//D.

from row in Regions 
select new 
{
	row.RegionDescription,
	row.Territories.Count
}

//E. 

from row in Regions 
select new 
{
	row.RegionDescription,
	row.Territories
}

//F.

from row in Regions 
select new 
{
	Region = row.RegionDescription,
	Territory = from item in row.Territories
					select item.TerritoryDescription
}

//G) List all the product names that contain the word "chef" in the name.
//H) List all the discontinued products, specifying the product name and unit price.
//I) List the company names of all Suppliers in North America (Canada, USA, Mexico)

//G.
from product in Products
where product.ProductName.Contains("chef")
select product

//H. 
from product in Products 
where product.Discontinued == true
select new 
{
	product.ProductName,
	product.UnitPrice
}
//I.

from supplier in Suppliers 
where supplier.Address.Country == "Canada" || 
		supplier.Address.Country == "USA" ||
		supplier.Address.Country == "Mexico"
select new
{
	supplier.CompanyName
}




















