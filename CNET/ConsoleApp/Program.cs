// See https://aka.ms/new-console-template for more information
using Model;
using Data;
Console.WriteLine("Hello, World!");

var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
var strings = new[] { "zero", "one", "two", "three", "four",
    "five", "six", "seven", "eight", "nine" };

Console.WriteLine(numbers.Select(n => strings[n]).Aggregate("Result: ", (a, b) => a + b + ","));
print(numbers.Select((n) => new { n, name = strings[n] }));

void print(IEnumerable<object> collection)
{
    foreach (object o in collection)
    {
        Console.WriteLine(o);
    }
}


static void FrequentWords()
{
    string booksdir = @"C:\Users\StudentEN\source\repos\CsharpSkolenie\CNET\Books";

    var files = Directory.EnumerateFiles(booksdir, "*.txt");
    foreach (var file in files)
    {
        var result = FreqAnalysis.FreqAnalysisFromFile(file);
        Console.WriteLine(new FileInfo(file).Name);

        //vytlacit 10 najcastejsich

        var ordered = result.OrderByDescending(a => a.Value).Take(10);
        foreach (var item in ordered)
        {
            Console.WriteLine($"{item.Key} {item.Value}");
        }
        Console.WriteLine();


    }

    FAResult fAResult = new FAResult()
    {
        Source = "file",
        SourceType = SourceType.FILE
    };

    Dictionary<string, int> x = Data.FreqAnalysis.FreqAnalysisFromFile(@"C:\Users\StudentEN\source\repos\CsharpSkolenie\CNET\Books\alice.txt");

    Console.WriteLine(fAResult);

    fAResult.Words = new Dictionary<string, int>();
    Console.WriteLine(fAResult);
}