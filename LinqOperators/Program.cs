// See https://aka.ms/new-console-template for more information

using LinqOperators.Data;
using LinqOperators.Models;

internal class Program
{
    public static void Main(string[] args)
    {
        string[] names = { "Tom" , "Dick", "Harry", "Jay"};
        /*var db = new NutshellContext();
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();*/
        WhereFilter(names);
        WhereIndexedFiltering(names);
    }
    
    private static void WhereFilter(string[] arr)
    {
        IEnumerable<string> query = arr.Where(name => name.EndsWith("y"));
        Console.WriteLine($"{nameof(query)} : [{string.Join(" ", query)}]");
    }

    private static void WhereIndexedFiltering(string[] arr)
    {
        IEnumerable<string> query = arr.Where((name, index) => index % 2 == 0);
        // An exception is thrown if you use indexed filtering in EF Core
        Console.WriteLine($"{nameof(query)} : [{string.Join(" ", query)}]");
    }

    private static void Paginator()
    {
        var dbContext = new NutshellContext();
        IQueryable<Customer> query = dbContext.Customers
            .Where(customer => customer.Name.Contains("a"))
            .OrderBy(customer => customer.Name)
            .Skip(20).Take(20);
    }

    private static void TakeAndSkipWhileFilter()
    {
        int[] numbers = {3, 5, 2, 234, 4, 1};
        var takewWhileSmall = numbers.TakeWhile(n => n < 100);
        var skipWhileSmall = numbers.SkipWhile(n => n < 100);
    }

    private static void DistinctFilter()
    {
        char[] distinctLetters = "HelloWorld".Distinct().ToArray();
        string s = new string(distinctLetters);

        new[] {1.0, 1.1, 2.0, 2.1, 3.0, 3.1}.DistinctBy(n => Math.Round(n, 0));
    }
}
