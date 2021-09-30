using System;
using System.Collections.Generic;

#nullable disable

namespace Project0.StoreApplication.Storage.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public short OrderId { get; set; }
        public byte CustomerId { get; set; }
        public byte StoreId { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
