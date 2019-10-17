<Query Kind="Statements">
  <Connection>
    <ID>2e8e2ff3-f136-4a08-bcfe-76710a50a684</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

DateTime.DaysInMonth(2020, 2).Dump("Days in Feb, 2020");
DateTime today = DateTime.Today;
var fivetoday = today.AddDays(5);
fivetoday.Dump();		//day //hour //sec //tentative
var delay = new TimeSpan(48, 15, 22);
delay.Dump();
today.Add(delay).Dump();
today.ToString("MMM dd yyyy").Dump();

