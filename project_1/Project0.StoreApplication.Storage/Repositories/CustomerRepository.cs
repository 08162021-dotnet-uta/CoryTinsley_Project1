using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project0.StoreApplication.Domain.Interfaces;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Adapters;
using Project0.StoreApplication.Storage.Models;
using Project0.StoreApplication.Storage.Models.Mapping;

namespace Project0.StoreApplication.Storage.Repositories
{

    public class CustomerRepository : IRepository<Customer>
    {
        private const string _path = @"C:/Users/cwall/source/repos/08162021-dotnet-uta/CoryTinsleyRepo1/projects/data/Customers.xml";

        public List<Customer_D> Customers { get; set; }
        //private static readonly FileAdapter _fileAdapter = new FileAdapter();
        private static readonly CustomerMapper _customerMapper = CustomerMapper.Instance;
        private static readonly StoreApplicationDBContext saDBContext = new StoreApplicationDBContext();



        public CustomerRepository()
        {





            //if (_fileAdapter.ReadFromFile<Customer_D>(_path) == null)
            //{
            //  _fileAdapter.WriteToFile<Customer_D>(_path, new List<Customer_D>()
            //  {
            //    //new Customer("Clypto"),
            //    //new Customer("Sam"),
            //    //new Customer("Ryan")

            //  });
            //}

            //  //Customers = Select();


        }


        public async Task<Customer_D> LoginCustomerAsync(Customer_D cust)
        {

            //convert from local customer to DB customer
            Customer c1 = _customerMapper.ViewModelToModel(cust);

            //Find customer in table using data in DB customer
            Customer c2 = await saDBContext.Customers.FromSqlRaw("SELECT * FROM Customer WHERE Name = {0}", cust.Name).FirstOrDefaultAsync();

            //check if null
            if (c2 == null) return null;

            //set information from db customer to local customer
            Customer_D c3 = _customerMapper.ModelToViewModel(c2);
            return c3;
        }

        public async Task<Customer_D> RegisterCustomerAsync(Customer_D cust)
        {


            //Sends customer data from local customer to DB customer
            Customer c = _customerMapper.ViewModelToModel(cust);
            //gets the amount of rows effected by the change
            int custIndex = await saDBContext.Database.ExecuteSqlRawAsync("INSERT INTO Customer (Name) VALUES ({0})", cust.Name);
            //if more or less than 1 row was effected by the change then something went wrong and return NULL
            if (custIndex != 1) return null;


            return await LoginCustomerAsync(cust);
        }




        public bool Delete(Customer entry)
        {
            //Customers.Remove(entry);
            return true;
        }

        public bool Insert(Customer entry)
        {
            //Customers.Add(entry);
            //_fileAdapter.WriteToFile<Customer>(_path, Customers);
            //_ef_Customers.SetCustomer(entry);

            return true;
        }


        public List<Customer> Select()
        {
            //return _fileAdapter.ReadFromFile<Customer>(_path);
            return saDBContext.Customers.FromSqlRaw("Select * from Customer;").ToList();
        }

        public Customer Update(Customer entry)
        {
            //Delete(entry);
            //Customers.Add(entry);
            // _fileAdapter.WriteToFile<Customer_D>(_path, Customers);
            return entry;
        }
    }
}