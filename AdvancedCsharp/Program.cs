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
        int[] values = new [] {  1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        
        Transformer(values, Square);

        Console.WriteLine($"Values: [{string.Join(", ", values)}]");
    }

    private static void CreatingDelegate()
    {
        MyTransformer t = Square; // shorthand to MyTransformer t = new MyTransformer(Square)
        int answer = t(3); // t(3) is a shorthand to t.Invoke(3);
        Console.WriteLine(answer);
    }

    private static void Transformer(int[] values, MyTransformer transformer)
    {
        for (int i = 0; i < values.Length; i++)  values[i] = transformer(values[i]);
    }
    private static int Square(int x) => x * x;
    private static int Cube(int x ) => x * x * x;
    private delegate int MyTransformer(int x);
}
