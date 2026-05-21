namespace AdvancedCsharp.NullableValueTypes;

public static class NullableValueTypes
{
    // Instead of reference tupes Value type cannot represent null values
    public static void S()
    {
        string s = null; // reference type
        // int i = null; // compile error
        int? ii = null; // we must use ? to value type accept null
        
        /*
         * The conversion from T to T? is implicit, whereas from T? to T the
         * conversion is explicti
         */
        int? x = 5; // implicit
        int y = (int) x; // explicit
    }

}