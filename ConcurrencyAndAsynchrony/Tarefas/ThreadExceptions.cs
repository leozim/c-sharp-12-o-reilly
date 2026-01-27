namespace ConcurrencyAndAsynchrony.Tarefas;

public static class ThreadExceptions
{
    public static void Exceptions()
    {
        Task task = Task.Run(() =>
        {
            throw null;
        });

        try
        {
            task.Wait();
        }
        catch (AggregateException ex)
        {
            if (ex.InnerException is NullReferenceException)
            {
                Console.WriteLine("Null!");
            }
            else
            {
                throw;
            }
        }
    }
}