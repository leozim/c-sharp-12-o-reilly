namespace ConcurrencyAndAsynchrony.Tarefas;

public static class Tasks
{
    /*
     * The Task class is a higher-level abstraction -- it represents a concurrent operation that
     * might or might not be backed by a thread. Tasks are compositional (you can chain them to-
     * gether through the use of continuations). They can use the thread pool to lessen startup
     * latency, and with a TaskCompletionSource, they can employ a callback approach that avoids
     * threads altogether while waiting on I/O-bound operations.
     */

    public static void Exceptions()
    {
        
    }
    
    public static void Continuations()
    {
        
    }
    
    public static void TaskCompletionSource()
    {
        
    }
    
    public static void TaskDelay()
    {
        // assynchronus form of Thread.Sleep()
    }
}