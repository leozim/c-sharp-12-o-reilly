namespace AdvancedCsharp.DelegateVersusInterface;

/*
 * A PROBLEM THAT YOU CAN SOLVE WITH A DELEGATE CAN ALSO BE SOLVED WITH AN
 * INTERFACE.
 */
public interface IDelegateVersusInterface
{
    public int Transform(int x);
}

public class Util
{
    public static void TransformAll(int[] values, IDelegateVersusInterface t)
    {
        for (int i = 0; i < values.Length; i++)
            values[i] = t.Transform(values[i]);
    }
}

/*
 *  A delegate design might be a better choice than an interface design if one or
    more of these conditions are true:
    The interface defines only a single method.
    Multicast capability is needed.
    The subscriber needs to implement the interface multiple times
 */
public class Squarer : IDelegateVersusInterface
{
    public int Transform(int x) =>  x * x;
}

class Cuber : IDelegateVersusInterface 
{ 
    public int Transform (int x) => x * x * x; 
}