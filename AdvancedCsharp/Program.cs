// See https://aka.ms/new-console-template for more information

using AdvancedCsharp;
using AdvancedCsharp.DelegateVersusInterface;
using AdvancedCsharp.Event;
using Util = AdvancedCsharp.Util;

internal class Program
{
    public static void Main(string[] args)
    {
        // CreatingDelegate();
        // WritingPlugInMethodsWithDelegates();
        // InstanceTarget();
        // MulticastDelegate();
        // DelegateVersusInterface();
        // DelegateCompatibility();
        IntroductionToEvents();
    }
    
    public static void IntroductionToEvents()
    {
        Stock stock = new Stock("THPW");
        stock.Price = 27.10M;
        // Register with the PriceChanged event
        stock.PriceChanged += stockPriceChanged;
        stock.Price = 31.59M;
        stock.Price = 36.59M;
        stock.Price = 35.59M;
    }

    private static void stockPriceChanged(object source, PriceChangedEventArgs e)
    {
        if ((e.NewPrice - e.LastPrice) / e.LastPrice > 0.1M)
        {
            Console.WriteLine("Alert, 10% stock price increase!");
        }
        Console.WriteLine($"LastPrice: {e.LastPrice}");
        Console.WriteLine($"NewPrice: {e.NewPrice}");
    }

    delegate void D();
    delegate void D1();
    delegate void D2();
    private static void Method1() {}
    private static void DelegateCompatibility()
    {
        /*
         * DELEGATE TYPES ARE ALL INCOMPATIBLE WITH ONE ANOTHER, EVEN IF THEIR
         * SIGNATURES ARE THE SAME:
         */

        // D1 d1 = Method1;
        // D2 d2 = d1; // COMPILE ERROR;
        // D2 d2 = new D2(d1); // It is permitted
        
        /*
         * DELEGATE INSTANCES ARE CONSIDERED EQUAL IF THEY HAVE THE SAME METHODS TARGETS:
         */
        D d1 = Method1;
        D d2 = Method1;
        Console.WriteLine(d1 == d2); // true
        
        /*
         * MULTICAST DELEGATES ARE CONSIDERED EQUAL IF THEY REFERENCE THE SAME METHODS IN
         * THE SAME ORDER.
         */
    }

    private static void DelegateVersusInterface()
    {
        int[] values = {1, 2, 4};
        AdvancedCsharp.DelegateVersusInterface.Util.TransformAll(values, new Squarer());
        
        foreach (var value in values) Console.WriteLine(value);
    }

    private static void MulticastDelegate()
    {
        /*
         * SEE PAGES 269-271 TO CODE SAMPLES
         * 
         * ALL DELEGATE INSTANCES HAVE 'MULTICAST CAPABILITY'. THIS MEANS THAT A DELEGATE
         * INSTANCE CAN REFERENCE NOT JUST A SINGLE TARGET METHOD BUT ALSO A LIST OF TAR-
         * GET METHODS. THE +, - AND += OR -= OPERATORS COMBINE OR REMOVE DELEGATE INSTANCES.
         *
         * DELEGATES ARE IMMUTABLE, SO WHEN YOU CALL += OR -=, YOU'RE IN FACT CREATING A NEW
         * DELEGATE INSTANCE AND ASSIGNING IT TO THE EXISTING VARIABLE.
         *
         * IF A MULTICAST DELEGATE HAS A NONVOID RETURN TYPE, THE CALLER RECEIVES THE RETURN
         * VALUE FROM THE LAST METHOD TO BE INVOKED. THE PRECEDING METHODS ARE STILL CALED,
         * BUT THEIR RETURN VALUES ARE DISCARDED. FOR MOST SCENARIOS IN WHICH MULTICAST DELE-
         * GATES ARE USED, THEY HAVE VOID RETURN TYES, SO THIS SUBTLETY(PECULIARIDADE) DOES
         * NOT ARISE.
         */

        ProgressReporter multicastDelegate = Util.WriteProgressToConsole;
        multicastDelegate += Util.WriteProgressToFile;
        Console.WriteLine(multicastDelegate.Target is null);
        
        if (System.IO.File.Exists("progress.txt"))
        {
            System.IO.File.Delete("progress.txt");
        }
        Util.HardWork(multicastDelegate);

    }
    
    /*  When an instance method is assigned to a delegate obect, the latter
        maintains a reference not only to the method but also to the instance to
        which the method belongs.
     */
    private static void InstanceTarget()
    {
        MyReporter r = new MyReporter();
        r.Prefix = "%Completed: ";
        ProgressReporter p = r.ReportProgress;
        p(99);
        Console.WriteLine(p.Target == r);
        Console.WriteLine(p.Method);

        r.Prefix = "";
        p(100);

    }

    private static void WritingPlugInMethodsWithDelegates()
    {
        int[] values = new [] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        
        Transformer(values, (Func<int,int>)Square);

        Console.WriteLine($"Values: [{string.Join(", ", values)}]");
    }

    private static void CreatingDelegate()
    {
        MyTransformer<int> t = Square; // shorthand to MyTransformer t = new MyTransformer(Square)
        int answer = t(3); // t(3) is a shorthand to t.Invoke(3);
        Console.WriteLine(answer);
    }

    private static void Transformer<T>(T[] values, MyTransformer<T> transformer)
    {
        for (int i = 0; i < values.Length; i++)  values[i] = transformer(values[i]);
    }
    
    private static void Transformer<T>(T[] values, Func<T,T> transformer)
    {
        for (int i = 0; i < values.Length; i++)  values[i] = transformer(values[i]);
    }
    
    private static int Square(int x) => x * x;
    private static int Cube(int x ) => x * x * x;
    private delegate T MyTransformer<T>(T x);
}
