namespace AdvancedCsharp;

public static class LearningEnumeration
{
    /*
     * Here is the high-level way of iterating through the characters in the word "beer"
     * using a FOREACH statement
     */
    public static void HighLevelIterator()
    {
        foreach (char c in "beer") 
            Console.WriteLine(c);
    }

    public static void LowLevelIterator()
    {
        using (var enumerator = "beer".GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                var element = enumerator.Current;
                Console.WriteLine(element);
            }
            
        }
    }
}

public static class LearningIterators
{
    /*
     * Whereas a FOREACH statemente is a consumer of a enumerator, an iterator is
     * a produces of an enumerator.
     * Below we'll using an iterator to return a fib's sequence
     */

    public static IEnumerable<int> Fibs(int fibCount)
    {
        for (int i = 0, prevFib = 1, curFib = 1; i < fibCount; i++)
        {
            yield return prevFib;
            int newFib = prevFib + curFib;
            prevFib = curFib;
            curFib = newFib;
        }
    }

    public static IEnumerable<int> EvenNumbersOnly(IEnumerable<int> sequence)
    {
        foreach (int number in sequence) if (number % 2 == 0) yield return number;
    }

    public static IEnumerable<int> Consumable()
    {
        return EvenNumbersOnly(Fibs(6));
    }

    public static IEnumerable<string> Foo()
    {
        yield return "foo";
        yield return "bar";
        yield return "baz";
    }
    
    /*
     * A 'return' statement is illegal in an iterator block; instead you must use the
     * 'yield break' statement to indicate that the iterator block should exit early,
     * without returning more element.
     */

    public static IEnumerable<string> Bar(bool breakEarly)
    {
        yield return "bar";
        yield return "baz";

        if (breakEarly) 
            yield break;
        
        yield return "buzz";
    }
    
}