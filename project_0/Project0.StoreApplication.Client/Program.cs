using System;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Client.Singletons;
using Project0.StoreApplication.Domain.Models;
using Serilog;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Project0.StoreApplication.Client
{

    /// <summary>
    /// Defines the Program Class
    /// </summary>
    class Program
    {

        private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
       // private static readonly CustomerSingleton _customerSingleton = CustomerSingleton.Instance;
        private static readonly ProductSingleton _productSingleton = ProductSingleton.Instance;
        private static readonly OrderSingleton _orderSingleton = OrderSingleton.Instance;
        private static List<string> confirmationList = new List<string>() { "Yes", "No" };


        private const string _logFilePath = @"C:/Users/cwall/source/repos/08162021-dotnet-uta/CoryTinsleyRepo1/projects/data/logs.txt";
        private static bool running = true;

        private static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File(_logFilePath).CreateLogger();

            //using(StoreApplicationDBContext context = new StoreApplicationDBContext())
            //{
            //    List<Customer> customers = context.Customers.FromSqlRaw("SELECT * FROM Customers").ToList();
            //}

            //Run();
        }



        /// <summary>
        /// Program Flow
        /// </summary>
        private static void Run()
        {
           // var customer = new Customer();
            bool newCustomer = LandingPage();


            if (newCustomer)
            {
                Console.WriteLine("What is your name?");
                //_customerSingleton.CreateCustomer(Console.ReadLine());

            }
            else
            {
                //saves customer the user selects 
                // customer = SelectCustomer();
            }







            do
            {





                //saves store the user selects
                //var store = SelectStore();

                //Shows product list and saves selected product
                // SelectProduct(store, customer);



                Console.WriteLine("Do you wish to exit the application?");
                var option = CaptureOutput<string>(confirmationList);
                if (option == 1)
                {
                    running = false;
                }





                //Select order
            } while (running == true);




            /// Console.WriteLine(customer);

        }

        public static bool LandingPage()
        {
            Console.WriteLine($"Welcome to 'Insert Generic Site Name Here' where your money is always appreciated!");
            Console.WriteLine("Are You a New or Existing customer?");
            var option = CaptureOutput<string>(new List<string> { "New", "Existing" });
            if (option == 1)
            {
                return true;
            }
            return false;
        }




        //public static Customer SelectCustomer()
        //    {

        //        //var customer = _customerSingleton.Customers[CaptureOutput<Customer>(_customerSingleton.Customers) - 1];
        //        // Log.Information($"SelectCustomer {customer}");     
        //        //return customer;

        //    }

        public static void /*Store*/ SelectStore()
        {
            // var store = _storeSingleton.Stores[CaptureOutput<Store>(_storeSingleton.Stores) - 1];
            //Console.WriteLine("You selected: " + store);
            //Log.Information($"SelectStore {store}");
            return;
        }


        //public static void SelectProduct(Store store, Customer customer)
        //{
        //    var products = _productSingleton.SortProducts(store);
        //    var selectedProduct = CaptureOutput<Product>(products) - 1;
        //    Log.Information($"SelectProduct {selectedProduct}");

        //    Console.WriteLine($"Do you want to buy {products[selectedProduct]}");
        //          var choice = CaptureOutput<string>(confirmationList);


        //         if (choice == 1)
        //    _orderSingleton.CreateOrder(new List<Product>() { products[selectedProduct] }, store, customer);
        //    Log.Information($"Created Order");
        //}


        /// <summary>
        /// Print list to console
        /// </summary>
        /// <typeparam name="T"></typeparam>
        static void ConsoleOutput<T>(List<T> data) where T : class
        {
            int i = 1;
            Log.Information($"ConsoleOutput<{typeof(T)}>");

            foreach (var item in data)
            {
                System.Console.WriteLine($"{i++} - {item}");
                //i += 1;
            }
        }



        /// <summary>
        /// Capture User input
        /// </summary>
        /// <typeparam name="T"></typeparam>
        static private int CaptureOutput<T>(List<T> data) where T : class
        {

            ConsoleOutput<T>(data);

            Console.WriteLine($"Select {typeof(T).Name}: ");

            int selected = int.Parse(Console.ReadLine());



            return selected;
        }
    }
}
