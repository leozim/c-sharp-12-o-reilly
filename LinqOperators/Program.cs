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
        SelectIndexedProjection(names);
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

    private static void SelectIndexedProjection(string[] input)
    {
        IEnumerable<string> query = input.Select((s, i) => string.Concat(i, "=", s));
        Console.WriteLine($"{nameof(query)} : [{string.Join(" ", query)}]");
    }
    
    /* JOINING */
    private static void ListWithoutNavigationProperty()
    {
        var dbContext = new NutshellContext();
        IQueryable<string> query =
            from c in dbContext.Customers // outer-key-expr
            join p in dbContext.Purchases // inner-key-expr
                on c.ID equals p.CustomerID // outer equals inner more efficiently
            select c.Name + " bought a " + p.Description;
        
        /*
            The results match what we would get from a 
            SelectMany-style query:
            Tom bought a Bike
            Tom bought a Holiday
            Dick bought a Phone
            Harry bought a Car
         */
    }

    private static void FluentSyntaxListWithoutNavigationProperty()
    {
        var dbContext = new NutshellContext();
        var customers = dbContext.Customers.ToList();
        var purchases = dbContext.Purchases.ToList();

        customers.Join( // outer collection
            purchases, // inner collection
            c => c.ID, // outer key selector
            p => p.CustomerID, // inner key selector
            (c, p) => new
            {
                c.Name,
                p.Description,
                p.Price
            }
        );
        
        customers
            .Join( // outer collection
                purchases, // inner collection
                c => c.ID, // outer key selector
                p => p.CustomerID, // inner key selector
                (c, p) => new { c, p}) // this keep c and p in scope
            .OrderBy(x => x.p.Price)
            .Select(x => x.c.Name + " bought a " + x.p.Description);
    }
    
    /* GROUP JOIN */
        
    
}
