namespace AdvancedCsharp;

public delegate void ProgressReporter(int percentComplete);

public class MyReporter
{
    public string Prefix { get; set; }

    public void ReportProgress(int percentComplete) 
        => Console.WriteLine($"{Prefix} {percentComplete}%");
}

public class Util
{
    public static void HardWork(ProgressReporter multicastDelegate)
    {
        for (int i = 1; i <= 10; i++)
        {
            multicastDelegate(i * 10);
            Thread.Sleep(100);
        }
    }
    
    public static void WriteProgressToConsole(int percentComplete)
        => Console.WriteLine(percentComplete);
    
    public static void WriteProgressToFile(int percentComplete) 
        => System.IO.File.AppendAllText("progress.txt", $"%Completed: {percentComplete}%\n");
}