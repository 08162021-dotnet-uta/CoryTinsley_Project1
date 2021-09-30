using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Repositories;

namespace Project0.StoreApplication.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class OrderSingleton
  {
    private static OrderSingleton _orderSingleton;
    private static readonly OrderRepository _orderRepository = new OrderRepository();
    /// <summary>
    /// List of Order Objects
    /// </summary>
    /// <value></value>
    public List<Order_D> Orders { get; private set; }
    public static OrderSingleton Instance
    {
      get
      {
        if (_orderSingleton == null)
        {
          _orderSingleton = new OrderSingleton();
        }

        return _orderSingleton;
      }
    }


    private OrderSingleton()
    {
      Orders = _orderRepository.Select();
    }

    /// <summary>
    /// Creates order Object before storing
    /// </summary>
    /// <param name="products"></param>
    /// <param name="store"></param>
    /// <param name="customer"></param>
    public void CreateOrder(List<Product_D> products, Store_D store, Customer_D customer)
    {

      var order = new Order_D(customer.CustomerID, store.StoreID);
      Add(order);

            //if (customer.Orders.Equals(null))
            //{
            //    customer.Orders = new List<Order_D>();
            //    customer.Orders.Add(order);
            //}
            //else
            //{
            //    customer.Orders.Add(order);
            //}
    }

    public void GrabOrders(List<Customer_D> customers)
    {

            //List<Order_D> tempList = new List<Order_D>();
            //if (_orderRepository.Orders.Equals(null))
            //    _orderRepository.Select();
            //tempList = _orderRepository.Orders;
            //foreach( Customer_D c in customers)
            //{
                
            //    foreach(Order_D o in tempList)
            //    {
            //        if(c.CustomerID == o.CustomerID)
            //        {
            //            if (c.Equals(null))
            //            {
            //                c.Orders = new List<Order_D>();
            //                c.Orders.Add(o);
            //            }
            //            else
            //            {
            //                c.Orders.Add(o);
            //            }
            //        }
            //    }
            //}
    }


    /// <summary>
    /// Add order object to List
    /// </summary>
    /// <param name="order"></param>
    public void Add(Order_D order)
    {
      _orderRepository.Insert(order);
      Orders = _orderRepository.Select();
    }
  }
}