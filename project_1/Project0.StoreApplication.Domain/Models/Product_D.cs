

namespace Project0.StoreApplication.Domain.Models
{

  public class Product_D
  {
    public short ProductKey { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int StoreID { get; set; }
    public int Quantity { get; set; }

    public Product_D()
    {

    }
    public Product_D(string name, decimal price, int i)
    {
      Name = name;
      Price = price;
      StoreID = i;

    }

    public override string ToString()
    {
      return Name;
    }
  }//EOC
}//EON