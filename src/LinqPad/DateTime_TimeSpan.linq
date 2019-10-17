<Query Kind="Expression">
  <Connection>
    <ID>2e8e2ff3-f136-4a08-bcfe-76710a50a684</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

//Orders.Max(sale => sale.OrderDate).Value.Month
from sale in Orders 
where sale.OrderDate.Value.Month == 5
	&& sale.OrderDate.Value.Year == 2018
select new //sale
{
	Customer = sale.Customer.CompanyName,
	ResponseTime = sale.RequiredDate.Value - sale.OrderDate.Value,
	PaymentDueOn = sale.PaymentDueDate,
	FirstPayment = sale.Payments.First().PaymentDate,
	PaymentResponseTime = sale.Payments.First().PaymentDate - sale.PaymentDueDate
	
	
}