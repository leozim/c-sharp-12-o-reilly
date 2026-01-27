namespace ConcurrencyAndAsynchrony.Tarefas;

public static class ReturningValues
{
    public static Task<int> ReturningValuesFromTask()
    {
        Task<int> task = new Task<int>(() =>
        {
            Console.WriteLine("Returning an int");
            return 3;
        });

        Console.WriteLine(task.Result); // calling "Result" will block the current thread
        
        return Task.Run(() =>
        {
            Console.WriteLine("Returning an int");
            return 3;
        });
    }
    
    /* BLOCKING A THREAD BY CALLING RESULT */
    public static void TaskPrimeNumber()
    {
        Task<int> primeNumberTask = Task.Run(() =>
            Enumerable.Range(2, 3000000).Count(n =>
                Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));

        Console.WriteLine("Task running...");
        Console.WriteLine($"The answer is {primeNumberTask.Result}");
    }
    
    public static Task<int> PrimeNumber()
    {
        return Task.Run(() =>
            Enumerable.Range(2, 3000000).Count(n =>
                Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
    }
}