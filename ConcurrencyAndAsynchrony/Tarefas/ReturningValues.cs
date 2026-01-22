namespace ConcurrencyAndAsynchrony.Tarefas;

public static class ReturningValues
{
    public static Task<int> ReturningValuesFromTask()
    {
        // Task<int> task = new Task<int>(() =>
        // {
        //     Console.WriteLine("Returning an int");
        //     return 3;
        // });
        
        return Task.Run(() =>
        {
            Console.WriteLine("Returning an int");
            return 3;
        });
    }
}