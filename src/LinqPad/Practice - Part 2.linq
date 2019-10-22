<Query Kind="Expression">
  <Connection>
    <ID>30c0f6f2-6bbe-4a87-9038-e12f48c00908</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// Practice questions - do each one in a separate LinqPad query.

// A) Group employees by region and show the results in this format:
/* ----------------------------------------------
 * | REGION        | EMPLOYEES                  |
 * ----------------------------------------------
 * | Eastern       | ------------------------   |
 * |               | | Nancy Devalio        |   |
 * |               | | Fred Flintstone      |   |
 * |               | | Bill Murray          |   |
 * |               | ------------------------   |
 * |---------------|----------------------------|
 * | ...           |                            |
 * 
 */

from place in Regions
select new 
{
	Region = place.RegionDescription,
	Employees = (from area in place.Territories
					from manager in area.EmployeeTerritories
						select manager.Employee.FirstName + " " + manager.Employee.LastName).Distinct(),
	Employees2 = from area in place.Territories
					from manager in area.EmployeeTerritories
						group manager by manager.Employee into areaManagers
						select areaManagers.Key.FirstName + " " + areaManagers.Key.LastName
					
}


// B) List all the Customers by Company Name. Include the Customer's company name, contact name, and other contact information in the result.

from row in Customers
group row by row.CompanyName into CustomersByCompanyName
select new 
{
	CompanyName = CustomersByCompanyName.Key,
	Customer = from data in CustomersByCompanyName
						select new 
						{
							ContactName = data.ContactName,
							ContactTitle = data.ContactTitle,
							ContactEmail = data.ContactEmail,
							Phone = data.Phone,
							Fax = data.Fax						
						}
}

// C) List all the employees and sort the result in ascending order by last name, then first name. Show the employee's first and last name separately, along with the number of customer orders they have worked on.


from row in Employees 
orderby row.LastName ascending, row.FirstName
select new 
{
	FirstName = row.FirstName,
	LastName = row.LastName,
	CustomerOrders = row.SalesRepOrders.Count
}

// E) Group all customers by city. Output the city name, aalong with the company name, contact name and title, and the phone number.

from row in Customers 
group row by row.Address.City into CustomersByCity
select new 
{
	City = CustomersByCity.Key,
	ContactInformation = from data in CustomersByCity
						select new 
						{
							CompanyName = data.CompanyName,
							ContactName = data.ContactName,
							Title = data.ContactTitle,
							Phone = data.Phone					
						}
}

// F) List all the Suppliers, by Country

from row in Suppliers
group row by row.Address.Country into SuppliersByCountry
select new 
{
	Country = SuppliersByCountry.Key,
	Supplier = from data in SuppliersByCountry
					{
							Supplier =	data.CompanyName
					}
}


















