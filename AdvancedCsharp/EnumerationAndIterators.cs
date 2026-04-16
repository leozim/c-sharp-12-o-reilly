namespace AdvancedCsharp;

public class LearningEnumeration
{
    /*
     * Here is the high-level way of iterating through the characters in the word "bee"
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

public class LearningIterators
{
    /*
     * Whereas a FOREACH statemente is a consumer of a enumerator, an iterator is
     * a produces of an enumerator.
     * Below we'll using an iterator to return a fib's sequence
     */

    public IEnumerable<int> Fibs(int fibCount)
    {
        for (int i = 0, prevFib = 1, curFib = 1; fibCount < i++)
        {
            yield return prevFib;
            int newFib = prevFib + curFib;
            prevFib = curFib;
            curFib = newFib;
        }
    }

    public IEnumerable<string> Foo()
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
}