// See https://aka.ms/new-console-template for more information
using Data;

//nahranie do db
var dataset = Serialization.LoadFromXML(@"C:\Users\StudentEN\source\repos\CsharpSkolenie\CNET\PersonDataset\dataset.xml");
using var db = new PeopleContext();
db.Persons.AddRange(dataset);
db.SaveChanges();

Console.WriteLine("Data boli ulozene do DB");

