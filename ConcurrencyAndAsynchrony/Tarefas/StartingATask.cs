namespace ConcurrencyAndAsynchrony.Tarefas;

public static class StartingATask
{
    public static void StartingATaskBackedByAThread()
    {
        Task.Run(
            () => Console.WriteLine("Starting a task backed by a thead."));
        /*
         * Tasks use pooled threads by default, which are background threads. This means that
         * when the main thread ends, so do any tasks that you create. Hence, you most block
         * the main thread after starting the task (for instance, by Wait[ing] the task or by
         * calling Console.ReadLine):
         */
        
        Task.Run(
            () => Console.WriteLine("Blocking Main thread to avoid finishing tasks.")
        );
        Console.ReadLine();
        
        // Calling Task.Run in this manner is similar to starting a thread as follows
        new Thread(() => Console.WriteLine("Foo"))
            .Start();
    }

    public static void WaitingATaskBackedByAThread()
    {
        Task task = Task.Run(() =>
        {
            Thread.Sleep(2000);
            Console.WriteLine("Waiting a task backed by a thread.");
        });
        Console.WriteLine(task.IsCompleted);
        task.Wait();
    }
    
    /*
     * By default, the CLR run tasks on pooled threads, which is ideal for short-
     * -running compute-bound work. For longer-running and blocking operations (
     * such as our preceding example WaitingATaskBackedByAThread()), you can pre-
     * vent use of a pooled thread as follows:
     */
    public static void LongRunningTasks()
    {
        Task task = Task
            .Factory
            .StartNew(() =>
                {
                    Thread.Sleep(2000);
                    Console.WriteLine("waiting...");
                },
                TaskCreationOptions.LongRunning);
        Console.WriteLine(task.IsCompleted);
        task.Wait();
    }
}