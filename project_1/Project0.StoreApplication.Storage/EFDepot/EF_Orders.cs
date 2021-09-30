using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Adapters;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Project0.StoreApplication.Storage.EFDepot
{
    class EF_Orders
    {

        private readonly DataAdapter _da = new DataAdapter();

        public List<Order_D> GetOrders()
        {
            return _da.Orders.FromSqlRaw("Select * from [Order].[Order];").ToList();
        }

        public void SetOrder(Order_D order)
        {
            _da.Database.ExecuteSqlRaw("insert into [Order].[Order](CustomerID, StoreKey, OrderDate) values ({0}, {1}, {2})", order.CustomerID, order.StoreKey, order.OrderDate);
        }
    }
}