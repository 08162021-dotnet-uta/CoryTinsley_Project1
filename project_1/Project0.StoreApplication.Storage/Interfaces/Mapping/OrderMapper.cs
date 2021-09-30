using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Interfaces;



namespace Project0.StoreApplication.Storage.Models.Mapping
{
    class OrderMapper : IModelMapper<Order, Order_D>
    {
        public Order_D ModelToViewModel(Order entry)
        {
            Order_D c = new Order_D();
            c.OrderID = entry.OrderId;
            c.StoreKey = entry.StoreId;
            c.OrderDate = entry.OrderDate;
            c.CustomerID = entry.CustomerId;

            return c;
        }

        public Order ViewModelToModel(Order_D entry)
        {
            Order c = new Order();
            c.OrderDate = entry.OrderDate;
            return c;
        }
    }//EOC
}//EON

