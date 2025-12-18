// See https://aka.ms/new-console-template for more information

using System.Text;
using Microsoft.VisualBasic.CompilerServices;

internal class Program
{
    public static void Main(string[] args)
    {
        StringType();
        Console.WriteLine(default(decimal));
        RefModifier();

        // Local ref(pointers ?)
        int[] arr = new int[] {1, 2, 3, 4, 5};

        // the target cannot be a prop
        ref int refArr = ref arr[2];

        Console.WriteLine(++refArr);
        Console.WriteLine($"O elemento no indíce 2 deve ser alterado para 4:  {arr[2]}");

        int cardNumber = 10;
        string cardName = cardNumber switch
        {
            13 => "King",
            12 => "Queen",
            11 => "Jack",
            _ => "Pip card" // equivalent to 'default'
        };
        Console.WriteLine(cardName);

        int cardNumber2 = 13;
        string suite = "spades";
        string cardName2 = (cardNumber2, suite) switch
        {
            (13, "spades") => "King of spades",
            (_, _) => "Pip card"
        };

        Console.WriteLine(cardName2);
    }

    private static void RefModifier()
    {
        StringBuilder sb = new StringBuilder();
        Foo(sb);
        Console.WriteLine(sb.ToString());
        Foo(ref sb);
        Console.WriteLine(sb?.ToString());
        
        // declaring variable on the fly when calling methods with out  parameters.
        Split("Leonardo Mariz Bezerra", out string firstName, out string lastName);
        Console.WriteLine(firstName);
        Console.WriteLine(lastName);
        
        // using discard
        Split("Luiz Alves", out _, out lastName);
        Console.WriteLine(lastName);
        
        Swap(ref firstName, ref lastName);
        Console.WriteLine($"{firstName}:{lastName}");

        int a = 3;
        int b = 4;
        Swap(ref a, ref b);
        Console.WriteLine($"{a}:{b}");
        
    }

    private static void Foo(StringBuilder sbFoo)
    {
        sbFoo.Append("Test");
        sbFoo = null;
    }
    
    private static void Foo(ref StringBuilder sbFoo)
    {
        sbFoo.Append("Test");
        sbFoo = null;
    }

    private static void Swap<T>(ref T a, ref T b)
    {
        // swap via destruction
        (a, b) = (b, a);
        /*
         T temp = a;
        a = b;
        b = temp;
        */
    }

    private static void Split(string name, out string a, out string b)
    {
        int i = name.LastIndexOf(' ');
        a = name.Substring(0, i);
        b = name.Substring(i + 1);
    }

    private static void Arrays()
    {
        throw new NotImplementedException();
    }

    private static void StringType()
    {
        // You can change the formatting by appending the e pression with a colon and a format string (format strings are described in
        string s = $"255 in hex is {byte.MaxValue:X2}";
        Console.WriteLine(s);

        bool b = true;
        // colon using
        // You can wrap the entire expression in parentheses to use a ternary conditional operator
        Console.WriteLine($"The answer in binary is {(b ? 1 : 0)}");
        
        // From C#10, interpolated strings can be constants, as long as the interpolated values are constants:
        const string greeting = "Hello";
        const string message = $"{greeting}, world";
    }
}
