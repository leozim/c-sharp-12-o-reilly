namespace LinqOperators.Models;

public class Customer
{
    public int ID { get; set; }
    public string Name { get; set; }

    public virtual List<Purchase> Purchases { get; set; }
      = new List<Purchase>();
}