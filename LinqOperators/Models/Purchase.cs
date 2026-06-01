using System.ComponentModel.DataAnnotations;

namespace LinqOperators.Models;

public class Purchase
{
  [Key]
  public int Id { get; set; }
  public int ID { get; set; }
  public int? CustomerID { get; set; }
  public DateTime Date { get; set; }
  public string Description { get; set; }
  public decimal Price { get; set; }

  public virtual Customer Customer { get; set; }
}