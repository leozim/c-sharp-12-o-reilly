// See https://aka.ms/new-console-template for more information

internal class Program
{
    public static void Main(string[] args)
    {
        CreatingDelegate();
        WritingPlugInMethodsWithDelegates();
    }

    private static void WritingPlugInMethodsWithDelegates()
    {
        
    }

    private static void CreatingDelegate()
    {
        MyTransformer t = Square; // shorthand to MyTransformer t = new MyTransformer(Square)
        int answer = t(3); // t(3) is a shorthand to t.Invoke(3);
        Console.WriteLine(answer);
    }

    private delegate int MyTransformer(int x);
    private static int Square(int x) => x * x;
}
