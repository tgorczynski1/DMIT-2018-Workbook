<Query Kind="Expression">
  <Connection>
    <ID>05a2444e-14ea-4451-ad3d-3398e9ff7898</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// Display the Employees, grouped by the region in which the employee lives. Show the employee's first name, last name, and job title as separate properties within each group.
from person in Employees
	//Employee  table<employee>
group person by person.Address.Region into EmployeeGroups
	//employee      <string> 				IGrouping<string, table>
select new
{
    Region = EmployeeGroups.Key,
	Employee = from staff in EmployeeGroups
	           select new
               {
			       FirstName = staff.FirstName,
				   LastName = staff.LastName,
				   JobTitle = staff.JobTitle
               }
}