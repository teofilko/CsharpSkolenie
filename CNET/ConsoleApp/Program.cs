// See https://aka.ms/new-console-template for more information
using Model;
using Data;
Console.WriteLine("Hello, World!");

int[] numbers = { 11, 2, 13, 44, -5, 6, 127, -99, 0, 256 };

//WHERE - filtracia
var resNums = numbers.Where(n => n > 0 && n < 100);

resNums.ToList().ForEach(x => Console.WriteLine(x));
foreach (var item in resNums)
{
    Console.WriteLine(item);
}

Console.WriteLine();

//ORDERBY
var resOrder = numbers.OrderBy(x => x);

//AGREGACIA
var resMax = numbers.Max();//  .Max(x => x);
var resSum = numbers.Sum();

//TAKE SKIP
var resTake = numbers.Take(2);
var resTakeWhile = numbers.TakeWhile(x => x > 0);
Console.WriteLine(resTakeWhile);

//SELECT - transformacia
Console.WriteLine(numbers.Select(x => Math.Abs(x)).ToList());

Console.WriteLine(numbers.Where(x => x > 0).Count());

Console.WriteLine(numbers.Distinct().OrderBy(n => n).Skip(1).SkipLast(1).Average());
Console.WriteLine(numbers.Where(a => a % 2 == 0).Count());
Console.WriteLine(numbers.Where(a => a % 2 != 0).Count());


void print(object colection)
{
    foreach (object o in colection.)
    {
        Console.WriteLine(o)
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