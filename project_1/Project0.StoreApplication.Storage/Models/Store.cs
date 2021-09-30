using System;
using System.Collections.Generic;

#nullable disable

namespace Project0.StoreApplication.Storage.Models
{
    public partial class Store
    {
        public Store()
        {
            Orders = new HashSet<Order>();
            Products = new HashSet<Product>();
        }

        public byte StoreId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
