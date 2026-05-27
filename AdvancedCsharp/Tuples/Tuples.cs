namespace AdvancedCsharp.Tuples;

public static class Tuples
{
    public static void demo()
    {
        var bob = ("Bob", 23);    
        // Allow compiler to infer the element types 
        Console.WriteLine (bob.Item1);   // Bob 
        Console.WriteLine (bob.Item2);   // 23
        
        var joe = bob;                 
        joe.Item1 = "Joe";             
        Console.WriteLine (bob);       
        Console.WriteLine (joe);       
        // joe is a *copy* of bob 
        // Change joe’s Item1 from Bob to Joe 
        // (Bob, 23) 
        // (Joe, 23)

        (string, int) person = GetPerson();
        Console.WriteLine(person.Item1);
        Console.WriteLine(person.Item2);

        (string, int) GetPerson() => ("Leo", 31);
        
        // Tuples play well wi genrecis, so the following types are all legal:
        Task<(string, int)> some;
        Dictionary<(string, int), Uri> thing;
        IEnumerable<(int id, string name)> whatever;
        
        // You can optionally give meaningful names to elements when creating tuple literals:
        var tuple = (name: "Nardo", age: 31);
        Console.WriteLine(tuple.name);
        Console.WriteLine(tuple.age);
        
        (string name, int age) GetNamedParameterPerson() => ("Leo", 31);
        
        // Elements names are automatically INFERRED from property or field names:
        var now = DateTime.Now;
        var tup = (now.Day, now.Month, now.Year);
        Console.WriteLine(tup.Day);
        
        // deconstruct a tuple
        var leonardo = ("leonardo", 31);
        (string name, int age) = leonardo;
        Console.WriteLine(name);
        Console.WriteLine(age);

    }
}