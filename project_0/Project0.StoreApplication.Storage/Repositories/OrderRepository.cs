using System;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Interfaces;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Adapters;
using Project0.StoreApplication.Storage.EFDepot;

namespace Project0.StoreApplication.Storage.Repositories
{

  public class OrderRepository : IRepository<Order_D>
  {
    private const string _path = @"/home/clypto/revature/training_code/projects/data/Orders.xml";
    public List<Order_D> Orders { get; private set; }
    //private static readonly FileAdapter _fileAdapter = new FileAdapter();
    private static readonly EF_Orders _ef_Orders = new EF_Orders();

    public OrderRepository()
    {
          //if (_fileAdapter.ReadFromFile<Order>(_path) == null)
          //{
          //  _fileAdapter.WriteToFile<Order>(_path, new List<Order>());
          //}

            Orders = Select();
    }
        private static OrderRepository _orderRepository;

        public static OrderRepository GetInstance()
        {

            if (_orderRepository == null)
            {
                _orderRepository = new OrderRepository();
            }

            return _orderRepository;
        }


        public bool Delete(Order_D entry)
    {
      throw new System.NotImplementedException();
    }


    public bool Insert(Order_D entry)
    {
      Orders.Add(entry);

            _ef_Orders.SetOrder(entry);
      //_fileAdapter.WriteToFile<Order>(_path, Orders);

      return true;
    }

    /// <summary>
    /// Get all Order records from DB
    /// </summary>
    /// <returns></returns>
    public List<Order_D> Select()
    {
        List<Order_D> tempOrder = _ef_Orders.GetOrders();
           // Console.WriteLine(tempOrder.Count);
            return tempOrder;



      //return _fileAdapter.ReadFromFile<Order>(_path);
      
        }

    public Order_D Update(Order_D entry)
    {
      throw new System.NotImplementedException();
    }
  }
}