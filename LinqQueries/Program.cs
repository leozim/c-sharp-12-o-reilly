// See https://aka.ms/new-console-template for more information
using System.Linq;
using System.Linq.Expressions;

namespace LinqQueries;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        
        // A sequence and its elements.
        string[] names = {"Tom", "Harry", "Dicky", "sandra"};

        IEnumerable<string> filteredNames = System.Linq.Enumerable.Where(names, n => n.Length > 3);
        Console.WriteLine($"{nameof(filteredNames)} : [{string.Join(" " ,filteredNames)}]");
        
        IEnumerable<string> shortLinq = names.Where(n => n.Length > 3);
        Console.WriteLine($"{nameof(shortLinq)} : [{string.Join(" ", shortLinq)}]");
        
        var shortestLinq = names.Where(n => n.Length > 3);
        Console.WriteLine($"{nameof(shortestLinq)} : [{string.Join(" " ,shortestLinq)}]");

        var contains = names.Where(n => n.Contains("a"));
        contains.ToList().ForEach(n => Console.WriteLine($"Name: {n}"));
        names.Where(n => n.Contains("a")).ToList().ForEach(n => Console.WriteLine($"LINQ/ForEach single line Name: {n}"));
        
        FluentSyntax();
        NaturalOrdering();
        OtherOperatos();

    }

    private static void QueryExpressionSyntax()
    {
        string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
        IEnumerable<string> filteredNames = from n in names
            where n.Contains("a")
            select n;
    }

    private static void FluentSyntax()
    {
        string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
        IEnumerable<string> query = names
            .Where(n => n.Contains("a"))
            // .OrderBy(n => n.Length)
            .OrderByDescending(n => n.Length)
            .Select(n => n.ToUpper());
        Console.WriteLine($"{nameof(query)} : [{string.Join(" ", query)}]");
        
        // Once Select's signature has <TSource, TResult>, take TSource and return a TResult that can be
        // different from TSource, from a string sequence we can return a int sequence.
        // The following query uses 
        // Select to transform string type elements to integer type elements:
        IEnumerable<int> queryIntFromString = names.Select(n => n.Length);
        Console.WriteLine($"{nameof(queryIntFromString)} : [{string.Join(" ", queryIntFromString)}]");
    }

    private static void NaturalOrdering()
    {
        int[] numbers = { 1, 3, 5, 7, 9, 8, 11 };
        IEnumerable<int> firstThree = numbers.Take(3);
        IEnumerable<int> lastTwo = numbers.Skip(4);
        IEnumerable<int> reverse = numbers.Reverse();

        IEnumerable<int> takeWhile = numbers.TakeWhile(n => n % 2 != 0); // so até o 9
        Console.WriteLine($"{nameof(takeWhile)} : [{string.Join(" ", takeWhile)}]");
    }

    private static void OtherOperatos()
    {
        int[] numbers = { 10, 9, 8, 7, 6 }; 
        int firstNumber  = numbers.First();                        
        int lastNumber   = numbers.Last();                         
        int secondNumber = numbers.ElementAt(1);
        // Second lowest
        int secondLowest = numbers.OrderBy(n=>n).Skip(1).First();  // 7
        
        // aggregation operator return scalar number
        int count = numbers.Count();
        int min = numbers.Min();
        
        // The quantifiers return a bool value
        bool hasTheNumberNine = numbers.Contains(9);
        bool hasMoreThanZeroElements = numbers.Any();
        bool hasAnOddElement = numbers.Any(n => n % 2 != 0);
        
        // Some query operators accept two input sequences
        int[] seq1 = {10, 30, 40, 80, 90};
        int[] seq2 = {1, 3, 4, 40, 8, 9, 90};
        
        IEnumerable<int> concat = seq1.Concat(seq2);
        // ignora repetidos na união("concatenação")
        IEnumerable<int> union = seq1.Union(seq2);
        
        Console.WriteLine($"{nameof(concat)} : [{string.Join(" ", concat)}]");
        Console.WriteLine($"{nameof(union)} ignora repetidos : [{string.Join(" ", union)}]");
    }
}
