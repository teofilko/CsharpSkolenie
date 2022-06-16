// See https://aka.ms/new-console-template for more information
using Data;
using Model;

using var db = new PeopleContext();
//nahranie do db
/*
var dataset = Serialization.LoadFromXML(@"C:\Users\StudentEN\source\repos\CsharpSkolenie\CNET\PersonDataset\dataset.xml");

db.Persons.AddRange(dataset);
db.SaveChanges();
*/
db.Contracts.First().Company = new Company { Name = "Test Company", Address = new Address { City = "Roznov",Street="1. Maje" } };
Console.WriteLine("Data boli ulozene do DB");
db.SaveChanges();

