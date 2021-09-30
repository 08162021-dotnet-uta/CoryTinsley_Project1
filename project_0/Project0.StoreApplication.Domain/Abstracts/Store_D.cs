using System.Collections.Generic;
using System.Xml.Serialization;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Domain.Abstracts
{

  [XmlInclude(typeof(ComputerStore))]
  [XmlInclude(typeof(MusicStore))]
  [XmlInclude(typeof(PenStore))]
  public abstract class Store_D
  {
    public byte StoreID { get; set; }
    public string Name { get; set; }
    public List<Order_D> Orders { get; set; }
    public List<Product_D> Products { get; set; }

    public Store_D()
    {

    }



    public override string ToString()
    {

      return Name;

    }



  }

}