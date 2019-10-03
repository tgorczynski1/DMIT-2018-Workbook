<Query Kind="Program" />

void Main()
{
	var result = from vendor in Suppliers
	select new SupplierSummary
	{
		CompanyName = vendor.CompanyName,
		Contact = vendor.ContactName,
		Phone = vendor.Phone,
		Products = from item in vendor.Products
				select new SupplierProduct
				{
					Name = item.ProductName,
					Category = item.Category
					Price = item.UnitPrice,
					PerUnitQuantity = item.QuantityPerUnit
				}
	
	};
	result.dump();
	
}


public class SupplierSummary
{
	public string CompanyName {get; set;}
	public string Contact {get; set;}
	public string Phone {get; set;}
	public IEnumerable<SupplierProduct> Products {get; set;}	
}

public class SupplierProduct
{
	public string Name {get; set;}
	public string Category {get; set;}
	public decimal Price {get; set;}
	public string PerUnitQuantity {get; set;}
}
/*
	Supplier:
	Company Name
	Contact Name
	Phone Number
		Product Summary:
			Product Name
			Category Name
			Unit Price
			Quantity/Unit	
	*/
// Define other methods and classes here
