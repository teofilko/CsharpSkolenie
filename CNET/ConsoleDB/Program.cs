// See https://aka.ms/new-console-template for more information
using Data;
using Model;

using var db = new PeopleContext();
//nahranie do db
/*
var dataset = Serialization.LoadFromXML(@"C:\Users\StudentEN\source\repos\CsharpSkolenie\CNET\PersonDataset\dataset.xml");

db.Persons.AddRange(dataset);

*/
//db.Contracts.First().Company = new Company { Name = "Test Company", Address = new Address { City = "Roznov",Street="1. Maje" } };
var emtyContractCompany = db.Contracts.Where(x => x.Company != null);
int i = 0;
foreach(var contract in emtyContractCompany)
{
    contract.Company = new Company() { Name = $"Test commpany {i++}", };
}
db.SaveChanges();


Console.WriteLine("Data boli ulozene do DB");
db.SaveChanges();

