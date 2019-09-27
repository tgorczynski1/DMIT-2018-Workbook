<Query Kind="Expression">
  <Connection>
    <ID>05a2444e-14ea-4451-ad3d-3398e9ff7898</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// Get the products displaying the product name, the category, and the unit price. Sort the results alphabetically by category and then in descending order by unit price.
from item in Products
orderby item.Category.CategoryName ascending, item.UnitPrice descending
select new
{
    Product = item.ProductName,
	Category = item.Category.CategoryName,
	Price = item.UnitPrice
}