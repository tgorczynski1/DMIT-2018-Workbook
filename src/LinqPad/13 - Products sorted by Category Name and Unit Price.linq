<Query Kind="Expression">
  <Connection>
    <ID>af508a97-5670-42ec-b71b-8cc473cabf0e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
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
}d