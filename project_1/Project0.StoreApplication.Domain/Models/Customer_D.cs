using System.Collections.Generic;

namespace Project0.StoreApplication.Domain.Models
{

  public class Customer_D
  {
    public string Name { get; set; }
    public byte CustomerID { get; set; }

    //public List<Order_D> Orders { get; set; }


    public Customer_D()
    {

    }



    public override string ToString()
    {
      return $"{Name} ";
    }
  }
}
//{Orders.Count}