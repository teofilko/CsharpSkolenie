// See https://aka.ms/new-console-template for more information
var dataset = Data.Serialization.LoadFromXML(@"C:\Users\StudentEN\source\repos\CsharpSkolenie\CNET\PersonDataset\dataset.xml");
Console.WriteLine(dataset.Count);
Console.Write("Pocet ludi z aspon jednou zmluvou");
Console.WriteLine(dataset.Where(p => p.Contracts.Count > 0).Count());
Console.WriteLine(dataset.Where(p => p.Contracts.Any()).Count()); // asi rychlejsie ako count

Console.Write("Pocet ludi z Brna ");
var Brnaci = dataset.Where(p => p.HomeAddress.City == "Brno");
Console.WriteLine(Brnaci.Count());
Console.WriteLine(string.Join(",\n", Brnaci));

Console.Write("Nejstarsi ");
var sortByAge = dataset.OrderBy(p => p.Age());
Console.WriteLine(sortByAge.Last());

Console.Write("Najmladsi ");
Console.WriteLine(sortByAge.First());

//anonymni typ
var newObjects = dataset.Select(p => new { p.FullName, p.DateOfBirth, Age = p.Age() });
foreach (var item in newObjects)
{
    Console.WriteLine(item.FullName + " " + item.DateOfBirth.ToString("dd.MMMM.yyyy", new System.Globalization.CultureInfo("sk")) + " " + item.Age);
}
Console.WriteLine();


//tuple
Console.WriteLine("tuples");
var newTuples = dataset.Select(p => (p.FullName, p.DateOfBirth, Age: p.Age()));
foreach (var item in newTuples)
{
    Console.WriteLine(item.FullName + " " + item.DateOfBirth.ToString("dd.MMMM.yyyy", new System.Globalization.CultureInfo("sk")) + " " + item.Age);
}


Console.WriteLine("");

//Group by
Console.WriteLine("Group by");
var gropCity = dataset.GroupBy(p => p.HomeAddress.City);
foreach (var item in gropCity)
{
    Console.WriteLine(item.Key + " " + item.Count());
}

gropCity.ToList().ForEach(g => g.ToList().ForEach(p => Console.WriteLine(g.Key + ":" + p.FullName)));

gropCity.ToList().ForEach(g => { Console.WriteLine(g.Key + "///////////////////////////"); g.ToList().ForEach(p => Console.WriteLine(p.FullName)); });

