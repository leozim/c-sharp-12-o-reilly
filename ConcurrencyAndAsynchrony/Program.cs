// See https://aka.ms/new-console-template for more 
using ConcurrencyAndAsynchrony.Tarefas;

using ConcurrencyAndAsynchrony;

internal class Program
{
    public static void Main(string[] args)
    {
        StartingATask.WaitingATaskBackedByAThread();
        StartingATask.LongRunningTasks();

        Task<int> task = ReturningValues.ReturningValuesFromTask();
        /*
         * If the task hasn't yet finished, accessing this property will block
         * the current thread until the task finishes:
         */
        int result = task.Result;
        Console.WriteLine(result);
        // ou
        Console.WriteLine(ReturningValues
            .ReturningValuesFromTask()
            .Result);
    }
}
