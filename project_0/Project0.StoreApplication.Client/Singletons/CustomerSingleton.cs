using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Models;
using Project0.StoreApplication.Storage.Repositories;

namespace Project0.StoreApplication.Client.Singletons
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerSingleton
    {
        private static CustomerSingleton _customerSingleton;
        private static readonly CustomerRepository _customerRepository = new CustomerRepository();
        //private static readonly OrderSingleton _orderSingleton = OrderSingleton.Instance;



        /// <summary>
        /// List of Customer Objects
        /// </summary>
        /// <value></value>
        public List<Customer_D> Customers { get; private set; }
        /// <summary>
        /// Dictionary used to hold store identifier
        /// </summary>
        public Dictionary<Customer_D, int> customerDictionary = new Dictionary<Customer_D, int>();

        public int currentCustomer = 0;




        public static CustomerSingleton Instance
        {
            get
            {
                if (_customerSingleton == null)
                {
                    _customerSingleton = new CustomerSingleton();
                }


                return _customerSingleton;
            }
        }


        private CustomerSingleton()
        {

            //Customers = _customerRepository.Select();

        }

        public void CreateCustomer(string Name)
        {
            _customerRepository.Insert(new Customer());
        }
        //
        //_orderSingleton.GrabOrders(Customers);


        /// <summary>
        /// Add customer object to XML
        /// </summary>
        /// <param name="customer"></param>
        public void Add(Customer customer)
        {
            _customerRepository.Insert(customer);
            //Customers = _customerRepository.Select();

        }

        public void UpdateCustomer(Customer customer)
        {
            //_customerRepository.Update(customer);
        }
    }
}