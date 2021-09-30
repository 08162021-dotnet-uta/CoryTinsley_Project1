using Microsoft.EntityFrameworkCore;
using Project0.StoreApplication.Storage.Models;
using System.Collections.Generic;
using System.Linq;

namespace Project0.StoreApplication.Storage.EFDepot
{
    class EF_Customers
    {
        private readonly StoreApplicationDBContext saDBContext = new StoreApplicationDBContext();


        //public List<Customer> GetCustomers()
        //        {
        //            return saDBContext.Customers.FromSqlRaw("Select * from Customer;").ToList();
        //        }

        public void SetCustomer(Customer customer)
        {
            saDBContext.Database.ExecuteSqlRaw("insert into Customer(Name) values ({0});", customer.Name);
        }
    }
}
