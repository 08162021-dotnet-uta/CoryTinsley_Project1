using System;
using System.Collections.Generic;

#nullable disable

namespace Project0.StoreApplication.Storage.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public byte CustomerId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
