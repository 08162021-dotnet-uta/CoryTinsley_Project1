using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Interfaces;



namespace Project0.StoreApplication.Storage.Models.Mapping
{
    public class CustomerMapper : IModelMapper<Customer, Customer_D>
    {

        public static CustomerMapper _customerMapper;
        public static CustomerMapper Instance
        {
            get
            {
                if (_customerMapper == null)
                {
                    _customerMapper = new CustomerMapper();
                }


                return _customerMapper;
            }
        }
        /// <summary>
        /// Takes in customer from DB and returns a customer 
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public Customer_D ModelToViewModel(Customer entry)
        {
            Customer_D c = new Customer_D();
            c.CustomerID = entry.CustomerId;
            c.Name = entry.Name;
            return c;
        }
        /// <summary>
        /// Takes in customer and returns customer for DB
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public Customer ViewModelToModel(Customer_D entry)
        {
            Customer c = new Customer();
            c.Name = entry.Name;
            return c;
        }
    }
}
