using System;
using System.Collections.Generic;

#nullable disable

namespace Project0.StoreApplication.Storage.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public short ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public byte StoreId { get; set; }
        public int Quantity { get; set; }

        public virtual Store Store { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
