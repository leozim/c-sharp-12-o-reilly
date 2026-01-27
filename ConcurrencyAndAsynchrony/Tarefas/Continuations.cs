using System.Runtime.CompilerServices;

namespace ConcurrencyAndAsynchrony.Tarefas;

public static class Continuations
{
    /*
     * A CONTINUATION SAYS TO A TASK, "WHEN YOU'VE FINISHED, CONTINUE BY DOING SOMETHING ELSE."
     * A CONTINUATION IS USUALLY IMPLEMENTED BY A CALLBACK THAT EXECUTES ONCE UPON COMPLETION OF
     * AN OPERATION.
     */
    public static void TaskContinuations()
    {
        Task<int> primeNumberTask = ReturningValues.PrimeNumber();

        TaskAwaiter<int> awaiter = primeNumberTask.GetAwaiter();
        awaiter.OnCompleted(() =>
        {
            int result = awaiter.GetResult();
            Console.WriteLine(result);
        });
        
        Task<int> primeNumberTaskContinueWith = ReturningValues.PrimeNumber();

        primeNumberTaskContinueWith.ContinueWith(
            antecedent =>
            {
                int result = antecedent.Result;
                Console.WriteLine(result);
            },
            TaskContinuationOptions.ExecuteSynchronously);
    }
}